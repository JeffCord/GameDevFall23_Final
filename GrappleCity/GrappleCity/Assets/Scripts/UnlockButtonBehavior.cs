using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockButtonBehavior : MonoBehaviour
{
    [SerializeField] GameObject exitDoor;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Crate")) {
            gameObject.SetActive(false);
            exitDoor.GetComponent<ExitBehavior>().isLocked = false;
            //Debug.Log(exitDoor.transform.GetChild(1).gameObject.name);
            exitDoor.transform.GetChild(1).gameObject.SetActive(false);
        }
    }
}
