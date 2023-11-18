using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidingDoorButtonBehavior : MonoBehaviour
{
    [SerializeField] public List<GameObject> slidingDoors = new List<GameObject>();

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Crate")) {
            foreach (GameObject slidingDoor in slidingDoors) {
                slidingDoor.SetActive(!slidingDoor.activeSelf);   
            }
            gameObject.SetActive(false);
        }
    }
}
