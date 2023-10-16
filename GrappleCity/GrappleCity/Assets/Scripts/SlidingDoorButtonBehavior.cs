using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidingDoorButtonBehavior : MonoBehaviour
{
    [SerializeField] GameObject slidingDoor;


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Crate")) {
            gameObject.SetActive(false);
            slidingDoor.SetActive(!slidingDoor.activeSelf);
        }
    }
}
