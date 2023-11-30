using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpKeyNuke2 : MonoBehaviour {
    // Interaction with smg
    public GameObject interactTextUI;
    public float theDistance;
    private float interactDistance = 3;

    // The fake smg box to disable once picked up
    public GameObject keyBox;
    public GameObject fakeKey;

    // Audio Clip
    public AudioSource pickUpKeyAuidoClip;

    // Inner dialogue
    public Image conversationPanelImage;
    public Text speakerLabel;
    public Text convoText;
    private string speaker1 = "Mud:";
    private string dialogue1 = "Got the key.";

    void Update() {
        theDistance = PlayerCasting.distanceFromTarget;
    }

    void OnMouseOver() {
        if (theDistance <= interactDistance && !GlobalChecks.gotKeyToRoom3) {
            interactTextUI.GetComponent<Text>().text = "Pick Up Key";
        }
        if(Input.GetButtonDown("Action") && theDistance <= interactDistance) {
            pickUpKeyAuidoClip.Play();
            GlobalChecks.gotKeyToRoom3 = true;
            OnMouseExit();
            StartCoroutine(Dialogue());
        }
    }

    void OnMouseExit() {
        interactTextUI.GetComponent<Text>().text = "";
    }

    IEnumerator Dialogue() {
        fakeKey.SetActive(false);
        conversationPanelImage.enabled = true;
        speakerLabel.text = speaker1;
        convoText.text = dialogue1;
        yield return new WaitForSeconds(3);
        convoText.text = "";
        speakerLabel.text = "";
        conversationPanelImage.enabled = false;
        keyBox.SetActive(false);
    }
}
