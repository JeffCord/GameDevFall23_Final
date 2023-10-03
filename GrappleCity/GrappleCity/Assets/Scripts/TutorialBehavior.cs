using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TutorialBehavior : MonoBehaviour
{
    private bool wasdMovementStep = false;
    private bool jumpStep = false;
    private bool dashStep = false;
    public bool gravityButtonStep = false;
    public bool secondGravityButtonHit = false;
    //private bool exitStep = false;
    [SerializeField] TextMeshProUGUI tutorialTextUI;
    [SerializeField] GameObject gravityButton1;
    [SerializeField] GameObject gravityButton2;
    [SerializeField] public GameObject unlockButton;
    [SerializeField] public GameObject exitDoor;

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
        else if (gravityButtonStep) {
            if (secondGravityButtonHit) {
                StartCoroutine(GravityButtonDelay());
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
        gravityButtonStep = true;
        //gravityButton1.SetActive(true);
        tutorialTextUI.text = "Touch a gravity button to invert gravity";
    }

    IEnumerator GravityButtonDelay() {
        float delay = 0.25f;
        yield return new WaitForSeconds(delay);
        gravityButtonStep = false;
        tutorialTextUI.text = "Touch the button with a key to unlock the exit door and complete the tutorial!";
        // exitDoor.SetActive(true);
        // unlockButton.SetActive(true);
    }
}