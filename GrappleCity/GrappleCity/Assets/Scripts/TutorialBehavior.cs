using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TutorialBehavior : MonoBehaviour
{
    private bool wasdMovementStep = false;
    private bool jumpStep = false;
    private bool dashStep = false;
    private bool gravityButton1Step = false;
    private bool gravityButton2Step = false;
    //private bool exitStep = false;
    [SerializeField] TextMeshProUGUI tutorialTextUI;
    [SerializeField] GameObject gravityButton1;
    [SerializeField] GameObject gravityButton2;
    [SerializeField] GameObject unlockButton;
    [SerializeField] GameObject exitDoor;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WelcomeMessage());
    }

    // Update is called once per frame
    void Update()
    {
        if (wasdMovementStep) {
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D)) {
                StartCoroutine(WasdDelay());
            }
        } 
        else if (jumpStep) {
            if (Input.GetKeyDown(KeyCode.Space)) {
                StartCoroutine(JumpDelay());
            }
        }
        else if (dashStep) {
            if (Input.GetMouseButtonDown(0)) {
                StartCoroutine(DashDelay());
            }
        }
        else if (gravityButton1Step) {
            if (!gravityButton1.activeSelf) {
                //gravityButton2.SetActive(false);
                StartCoroutine(GravityButton1Delay());
            }
        }
        else if (gravityButton2Step) {
            if (!gravityButton2.activeSelf) {
                //gravityButton1.SetActive(false);
                StartCoroutine(GravityButton2Delay());
            }
        }
    }

    IEnumerator WelcomeMessage()
    {
        float delay = 2.0f;
        yield return new WaitForSeconds(delay);
        wasdMovementStep = true;
        tutorialTextUI.text = "Use WASD keys to move";
    }

    IEnumerator WasdDelay() {
        float delay = 2.0f;
        yield return new WaitForSeconds(delay);
        wasdMovementStep = false;
        jumpStep = true;
        tutorialTextUI.text = "SPACE to jump";
    }

    IEnumerator JumpDelay() {
        float delay = 2.0f;
        yield return new WaitForSeconds(delay);
        jumpStep = false;
        dashStep = true;
        tutorialTextUI.text = "LEFT MOUSE BUTTON to dash (on the ground or in the air)";
    }

    IEnumerator DashDelay() {
        float delay = 2.0f;
        yield return new WaitForSeconds(delay);
        dashStep = false;
        gravityButton1Step = true;
        gravityButton1.SetActive(true);
        tutorialTextUI.text = "Touch a gravity button to invert gravity";
    }

    IEnumerator GravityButton1Delay() {
        float delay = 2.0f;
        yield return new WaitForSeconds(delay);
        gravityButton1Step = false;
        gravityButton2Step = true;
        //gravityButton2.SetActive(true);
        //tutorialTextUI.text = "Touch the gravity button on the ceiling to invert gravity again";
    }

    IEnumerator GravityButton2Delay() {
        float delay = 0.0f;
        yield return new WaitForSeconds(delay);
        gravityButton2Step = false;
        //exitStep = true;
        //gravityButton1.SetActive(false);
        exitDoor.SetActive(true);
        unlockButton.SetActive(true);
        tutorialTextUI.text = "Touch the button with a key to unlock the exit door and complete the tutorial!";
    }
}