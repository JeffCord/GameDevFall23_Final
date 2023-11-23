using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitBehavior : MonoBehaviour
{
    public bool isLocked = true;
    [SerializeField] string nextScene;
    private SpriteRenderer sr;
    private GameObject exitSign;
    private ParticleSystem ps;
    AudioManager audioManager;
    
    void Awake() {
        sr = gameObject.GetComponent<SpriteRenderer>();
        exitSign = gameObject.transform.GetChild(0).gameObject;
        ps = gameObject.transform.GetChild(3).gameObject.GetComponent<ParticleSystem>();
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isLocked) {
            sr.color = new Color(0f, 1f, 0f, 1f);
            exitSign.SetActive(false);
            other.gameObject.SetActive(false);
            audioManager.PlaySFX(audioManager.exitReachedSound);
            StartCoroutine(ExitReachedCoroutine());
        }
    }

    IEnumerator ExitReachedCoroutine() {
        ps.Play();

        // Wait for the particle system to stop playing
        while (ps.isPlaying)
        {
            yield return null;
        }

        SceneManager.LoadScene(nextScene);
    }
}
