using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitBehavior : MonoBehaviour
{
    public bool isLocked = true;
    [SerializeField] string nextScene;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isLocked) {
            // go to next level
            SceneManager.LoadScene(nextScene);
        }
    }
}
