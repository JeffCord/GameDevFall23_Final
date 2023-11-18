using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class PlayerMovement : MonoBehaviour
{
    private bool isAlive = true;

    Rigidbody2D rb;
    [SerializeField] float speed = 5;
    [SerializeField] float jumpForce = 5;

    [SerializeField] LayerMask groundMask;

    public float dashSpeed = 20f;
    public float dashDuration = 0.5f;

    public int gravityDir = 1;

    private SpriteRenderer sr;

    private BoxCollider2D bc;

    private ParticleSystem ps;

    public AudioClip dashSound; // Sound to play on mouse click
    public AudioClip jumpSound;
    public AudioClip unlockSound;
    private AudioSource audioSource;

    void Awake(){
        sr = GetComponent<SpriteRenderer>();
        bc = GetComponent<BoxCollider2D>();
        audioSource = GetComponent<AudioSource>();   
        rb = GetComponent<Rigidbody2D>();
        ps = GetComponent<ParticleSystem>();
    }

    void Update(){
        if (!PauseMenu.isPaused && isAlive) {
            if (Input.GetKey(KeyCode.A)) {
                Move(new Vector3(-1,0,0));
                transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
            } else if (Input.GetKey(KeyCode.D)) {
                Move(new Vector3(1,0,0));
                transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            } else {
                Stop();
            }

            if(Input.GetKeyDown(KeyCode.Space)){
                Jump();
            }

            if (Input.GetMouseButtonDown(0))
            {
                audioSource.clip = dashSound;
                audioSource.Play();
                StartCoroutine(DashCoroutine());
            }
        }
    }

    public void Move(Vector3 mvec){
        mvec *= speed;
        mvec.y = rb.velocity.y;
        rb.velocity = mvec;
    }

    public void Stop(){
        rb.velocity = new Vector3(0,rb.velocity.y,0);
    }

    public void Jump(){
        if (Physics2D.OverlapCircleAll(transform.position-new Vector3(0,gravityDir * .5f,0),0.5f,groundMask).Length > 0) {
            audioSource.clip = jumpSound;
            audioSource.Play();
            rb.AddForce(new Vector3(0,gravityDir * jumpForce,0),ForceMode2D.Impulse);
        }
    }

    IEnumerator DashCoroutine()
    {
        Vector2 dashDirection = new Vector3(1.0f, 0.0f, 0.0f); 
        if (transform.localScale.x == -1) {
            dashDirection *= -1;
        }

        float dashTime = 0;
        while (dashTime < dashDuration)
        {
            rb.velocity = dashDirection * dashSpeed;
            dashTime += Time.deltaTime;
            yield return null;
        }

        rb.velocity = Vector2.zero; // Stop the dash after the duration
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Spikes")) {
            isAlive = false;
            bc.enabled = false;
            rb.gravityScale = 0;
            sr.enabled = false;
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
            gameObject.transform.GetChild(1).gameObject.SetActive(false);
            StartCoroutine(DeathCoroutine());
        }
        else if (other.CompareTag("UnlockButton")) {
            audioSource.clip = unlockSound;
            audioSource.Play();
        }
        else if (other.CompareTag("SlidingDoorButton")) {
            audioSource.clip = unlockSound;
            audioSource.Play();
        }
    }

    IEnumerator DeathCoroutine() {
        ps.Play();

        // Wait for the particle system to stop playing
        while (ps.isPlaying)
        {
            yield return null;
        }
 
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
