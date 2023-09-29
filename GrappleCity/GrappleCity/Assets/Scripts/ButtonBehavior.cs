using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBehavior : MonoBehaviour
{
    [SerializeField] GameObject exitDoor;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Crate")) {
            exitDoor.GetComponent<ExitBehavior>().isLocked = false;
            exitDoor.transform.GetChild(1).gameObject.SetActive(false);
            gameObject.SetActive(false);
        }
    }
}
