using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenDoorBig : MonoBehaviour {
    // Interaction with button
    public GameObject interactTextUI;
    public float theDistance;
    private float interactDistance = 8;
    // Opening the door
    private bool openingDoor;
    public GameObject theDoor;
    // Inner dialogue
    public Image conversationPanelImage;
    public Text speakerLabel;
    public Text convoText;
    private string speaker1 = "Mud:";
    private string dialogue1 = "God damn that is one big ass door.";
    private string dialogue1_NoKey = "I need a key to open this huge fucking door.";

    // The enemies to spawn in
    public GameObject vampires;
    public GameObject spiders;
    

    void Update() {
        theDistance = PlayerCasting.distanceFromTarget;
    }

    void OnMouseOver() {
        if (theDistance <= interactDistance) {
            interactTextUI.GetComponent<Text>().text = "Press Button";
        }
        if(Input.GetButtonDown("Action") && theDistance <= interactDistance && !openingDoor && GlobalChecks.gotKeyToPowerPlant) {
            StartCoroutine(SummonEnemies());
            StartCoroutine(Dialogue());
            StartCoroutine(OpenTheDoor());
        }
        else if(Input.GetButtonDown("Action") && theDistance <= interactDistance && !openingDoor && !GlobalChecks.gotKeyToPowerPlant) {
            StartCoroutine(SummonEnemies());
            StartCoroutine(Dialogue_NoKey());
        }
    }

    void OnMouseExit() {
        interactTextUI.GetComponent<Text>().text = "";
    }

    IEnumerator OpenTheDoor() {
        openingDoor = true;
        theDoor.GetComponent<Animator>().enabled = true;
        yield return new WaitForSeconds(2);
        theDoor.GetComponent<Animator>().enabled = false;
        yield return new WaitForSeconds(10);
        theDoor.GetComponent<Animator>().enabled = true;
        yield return new WaitForSeconds(2);
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

    IEnumerator SummonEnemies() {
        // vampires.SetActive(true);
        // spiders.SetActive(true);
        yield return new WaitForSeconds(0.1f);
    }
}
