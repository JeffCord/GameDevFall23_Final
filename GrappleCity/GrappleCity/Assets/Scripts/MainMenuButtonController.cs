using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtonController : MonoBehaviour
{
    [SerializeField] AudioClip clickSound;
    [SerializeField] AudioSource audioSource;

    void Start() {

    }

    public void StartButton() {
        SceneManager.LoadScene("Level_01");
    }

    public void TutorialButton() {
        SceneManager.LoadScene("Tutorial");
    }

    public void QuitButton() {
        Application.Quit();
    }
}
