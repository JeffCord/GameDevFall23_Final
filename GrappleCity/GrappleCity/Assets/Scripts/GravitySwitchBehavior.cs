using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravitySwitchBehavior : MonoBehaviour
{
    [SerializeField] private GameObject gravityManagerObj;
    private GravityManager gravityManager;
    private List<GameObject> gravityAffectedObjects;
    private List<GameObject> gravitySwitches;
    AudioManager audioManager;

    void Awake() {
        gravityManager = gravityManagerObj.GetComponent<GravityManager>();
        gravityAffectedObjects = gravityManager.gravityAffectedObjects;
        gravitySwitches = gravityManager.gravitySwitches;
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Crate")) {
            
            audioManager.PlaySFX(audioManager.gravityButtonSound);

            foreach (GameObject currentObject in gravitySwitches)
            {
                if (currentObject == null) {
                    continue;
                }

                if (currentObject != gameObject && currentObject.CompareTag(gameObject.tag)) 
                {
                    currentObject.SetActive(false);
                } else {
                    currentObject.SetActive(true);
                }
            }

            foreach (GameObject currentObject in gravityAffectedObjects)
            {
                if (currentObject == null) {
                    continue;
                }

                if (currentObject.CompareTag("Player")) {
                    currentObject.GetComponent<PlayerMovement>().gravityDir *= -1;
                }

                Rigidbody2D curRb = currentObject.GetComponent<Rigidbody2D>();
                curRb.gravityScale *= -1;
            }

            gameObject.SetActive(false);
        }
    }
}
