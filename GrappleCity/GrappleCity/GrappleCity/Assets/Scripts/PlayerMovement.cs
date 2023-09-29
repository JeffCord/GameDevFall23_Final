using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float speed = 5;
    [SerializeField] float jumpForce = 5;

    [SerializeField] LayerMask groundMask;

    public float maxDashSpeed = 10f;     // Maximum dash speed when fully charged
    public float maxChargeTime = 2f;     // Time in seconds to reach maximum dash speed
    public float dashDuration = 0.5f;    // Duration of the dash

    private bool isCharging = false;     // Track if charging up
    private float chargeStartTime;       // Time when the charging started
    private float currentDashSpeed = 0f; // Current dash speed based on 

    public int gravityDir = 1;

    void Update(){
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
            // Start charging
            isCharging = true;
            chargeStartTime = Time.time;
        }

        if (isCharging && Input.GetMouseButtonUp(0))
        {
            // Calculate the charge duration
            float chargeDuration = Time.time - chargeStartTime;
            // Calculate the dash speed based on the charge duration
            //currentDashSpeed = Mathf.Lerp(0, maxDashSpeed, chargeDuration / maxChargeTime);
            
            currentDashSpeed = maxDashSpeed;

            // Stop charging
            isCharging = false;
            // Start dashing
            StartCoroutine(Dash());
        }
    }

    void Awake(){
        rb = GetComponent<Rigidbody2D>();
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
        if (Physics2D.OverlapCircleAll(transform.position-new Vector3(0,gravityDir * .5f,0),1,groundMask).Length > 0) {
            rb.AddForce(new Vector3(0,gravityDir * jumpForce,0),ForceMode2D.Impulse);
        }
    }

    IEnumerator Dash()
    {
        float dashTime = 0;
        Vector2 dashDirection = transform.right; // Assuming the player faces the right direction by default. Adjust if necessary.
        if (transform.localScale.x == -1) {
            dashDirection *= -1;
        }

        while (dashTime < dashDuration)
        {
            rb.velocity = dashDirection * currentDashSpeed;
            dashTime += Time.deltaTime;
            yield return null;
        }

        rb.velocity = Vector2.zero; // Stop the dash after the duration
    }
}
