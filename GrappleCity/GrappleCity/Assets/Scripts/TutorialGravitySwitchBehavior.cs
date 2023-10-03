using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialGravitySwitchBehavior : MonoBehaviour
{
    [SerializeField] GameObject levelBehavior;
    TutorialBehavior tutorialBehavior;

    void Awake() {
        tutorialBehavior = levelBehavior.GetComponent<TutorialBehavior>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && tutorialBehavior.gravityButtonStep) {
            tutorialBehavior.secondGravityButtonHit = true;
        }
    }
}
