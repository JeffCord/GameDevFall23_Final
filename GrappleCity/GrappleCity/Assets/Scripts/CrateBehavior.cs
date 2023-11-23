using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateBehavior : MonoBehaviour
{
    AudioManager audioManager;

    void Awake() {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("UnlockButton")) {
            audioManager.PlaySFX(audioManager.keyButtonSound);
        }
        else if (other.CompareTag("SlidingDoorButton")) {
            audioManager.PlaySFX(audioManager.slidingDoorButtonSound);
        }
    }
}
