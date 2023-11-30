using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenDoor001 : MonoBehaviour {
    // Interaction with button
    public GameObject interactTextUI;
    private float theDistance;
    private float interactDistance = 3;
    // Opening the door
    private bool openingDoor;
    public GameObject theDoor;
    // Inner dialogue
    public Image conversationPanelImage;
    public Text speakerLabel;
    public Text convoText;
    private string speaker1 = "Mud:";
    private string dialogue1 = "Been on the road awhile. I have to go into this town for some rest and work.";
    private string dialogue2 = "Got some vampires and spiders, ugly bastards. Can't let the spiders get close and let them entangle me with their webs.";
    private string dialogue3 = "Have to make sure to aim for their hearts when shooting them, or whats left of them.";

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
        if(Input.GetButtonDown("Action") && theDistance <= interactDistance && !openingDoor) {
            StartCoroutine(SummonVampires());
            StartCoroutine(Dialogue());
            StartCoroutine(OpenTheDoor());
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
        convoText.text = dialogue2;
        yield return new WaitForSeconds(8);
        convoText.text = dialogue3;
        yield return new WaitForSeconds(6);
        convoText.text = "";
        speakerLabel.text = "";
        conversationPanelImage.enabled = false;

    }

    IEnumerator SummonVampires() {
        vampires.SetActive(true);
        spiders.SetActive(true);
        yield return new WaitForSeconds(0.1f);
    }
}
