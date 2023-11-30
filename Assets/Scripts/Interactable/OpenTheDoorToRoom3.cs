using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenTheDoorToRoom3 : MonoBehaviour {
    // Interaction with button
    public GameObject interactTextUI;
    public float theDistance;
    private float interactDistance = 8;
    // Opening the door
    private bool openingDoor;
    private bool spoken;
    public GameObject theDoor;
    // Inner dialogue
    public Image conversationPanelImage;
    public Text speakerLabel;
    public Text convoText;
    private string speaker1 = "Mud:";
    private string dialogue1 = "The air here carries something sinister.";
    private string dialogue1_NoKey = "I need a key to open this door.";

    void Update() {
        theDistance = PlayerCasting.distanceFromTarget;
    }

    void OnMouseOver() {
        if (theDistance <= interactDistance) {
            interactTextUI.GetComponent<Text>().text = "Press Button";
        }
        if(Input.GetButtonDown("Action") && theDistance <= interactDistance && !openingDoor && GlobalChecks.gotKeyToRoom3) {
            if(!spoken) {
                StartCoroutine(Dialogue());
                this.spoken = true;
            }
            StartCoroutine(OpenTheDoor());
        }
        else if(Input.GetButtonDown("Action") && theDistance <= interactDistance && !openingDoor && !GlobalChecks.gotKeyToRoom3) {
            StartCoroutine(Dialogue_NoKey());
        }
    }

    void OnMouseExit() {
        interactTextUI.GetComponent<Text>().text = "";
    }

    IEnumerator OpenTheDoor() {
        openingDoor = true;
        theDoor.GetComponent<Animator>().enabled = true;
        yield return new WaitForSeconds(1);
        theDoor.GetComponent<Animator>().enabled = false;
        yield return new WaitForSeconds(5);
        theDoor.GetComponent<Animator>().enabled = true;
        yield return new WaitForSeconds(1);
        theDoor.GetComponent<Animator>().enabled = false;
        openingDoor = false;
    }
    IEnumerator Dialogue() {
        conversationPanelImage.enabled = true;
        speakerLabel.text = speaker1;
        convoText.text = dialogue1;
        yield return new WaitForSeconds(5);
        convoText.text = "";
        speakerLabel.text = "";
        conversationPanelImage.enabled = false;

    }

    IEnumerator Dialogue_NoKey() {
        conversationPanelImage.enabled = true;
        speakerLabel.text = speaker1;
        convoText.text = dialogue1_NoKey;
        yield return new WaitForSeconds(5);
        convoText.text = "";
        speakerLabel.text = "";
        conversationPanelImage.enabled = false;

    }
}
