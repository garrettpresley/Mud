using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpSmg : MonoBehaviour {
    // Interaction with smg
    public GameObject interactTextUI;
    public float theDistance;
    private float interactDistance = 3;
    public AudioSource pickUpGunAudioClip;

    // The fake smg box to disable once picked up
    public GameObject fakeMp5kBox;
    public GameObject fakeMp5k;

    // Inner dialogue
    public Image conversationPanelImage;
    public Text speakerLabel;
    public Text convoText;
    private string speaker1 = "Mud:";
    private string dialogue1 = "Hell yeah. Lets use it on some Vampire bastards.";

    // Enemies to spawn in once picked up
    public GameObject vampires;
    public GameObject spiders;
    

    void Update() {
        theDistance = PlayerCasting.distanceFromTarget;
    }

    void OnMouseOver() {
        if (theDistance <= interactDistance) {
            interactTextUI.GetComponent<Text>().text = "Pick Up MP5k";
        }
        if(Input.GetButtonDown("Action") && theDistance <= interactDistance) {
            pickUpGunAudioClip.Play();
            GlobalChecks.gotSmg = true;
            StartCoroutine(Dialogue());
            StartCoroutine(SummonEnemies());
            fakeMp5k.SetActive(false);
        }
    }

    void OnMouseExit() {
        interactTextUI.GetComponent<Text>().text = "";
    }

    IEnumerator Dialogue() {
        conversationPanelImage.enabled = true;
        speakerLabel.text = speaker1;
        convoText.text = dialogue1;
        yield return new WaitForSeconds(5);
        convoText.text = "";
        speakerLabel.text = "";
        conversationPanelImage.enabled = false;
        fakeMp5kBox.SetActive(false);
    }

    IEnumerator SummonEnemies() {
        vampires.SetActive(true);
        spiders.SetActive(true);
        yield return new WaitForSeconds(0.1f);
    }

}
