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
    private bool exitStep = false;
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
                wasdMovementStep = false;
                jumpStep = true;
                tutorialTextUI.text = "SPACE to jump";
            }
        } 
        else if (jumpStep) {
            if (Input.GetKeyDown(KeyCode.Space)) {
                jumpStep = false;
                dashStep = true;
                tutorialTextUI.text = "LEFT MOUSE BUTTON to dash (on the ground or in the air)";
            }
        }
        else if (dashStep) {
            if (Input.GetMouseButtonDown(0)) {
                dashStep = false;
                gravityButton1Step = true;
                gravityButton1.SetActive(true);
                tutorialTextUI.text = "Touch the gravity button on the ground to invert gravity";
            }
        }
        else if (gravityButton1Step) {
            if (!gravityButton1.activeSelf) {
                gravityButton1Step = false;
                gravityButton2Step = true;
                //gravityButton2.SetActive(true);
                tutorialTextUI.text = "Touch the gravity button on the ceiling to invert gravity again";
            }
        }
        else if (gravityButton2Step) {
            if (!gravityButton2.activeSelf) {
                gravityButton2Step = false;
                exitStep = true;
                gravityButton1.SetActive(false);
                unlockButton.SetActive(true);
                exitDoor.SetActive(true);
                tutorialTextUI.text = "Touch the button with a key to unlock the exit door and complete the tutorial!";
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
}