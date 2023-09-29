using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravitySwitchBehavior : MonoBehaviour
{
    [SerializeField] private List<GameObject> gravityAffectedObjects = new List<GameObject>();
    [SerializeField] private List<GameObject> otherGravitySwitches = new List<GameObject>();

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) {
            // go to next level
            foreach (GameObject currentObject in otherGravitySwitches)
            {
                if (currentObject == null) {
                    continue;
                }

                if (currentObject.CompareTag(gameObject.tag)) 
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
