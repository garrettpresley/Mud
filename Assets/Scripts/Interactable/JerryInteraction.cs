using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JerryInteraction : MonoBehaviour
{
    // Interaction with Jerry
    public GameObject interactTextUI;
    private float theDistance;
    private float interactDistance = 3;
    // Talking to Jerry
    private bool talking;
    public GameObject npc;
    // Inner dialogue
    public Image conversationPanelImage;
    public Text speakerLabel;
    public Text convoText;
    private string speaker1 = "Mud:";
    private string speaker2 = "Jerry:";
    
    private string dialogue1_1 = "I just rolled into town, where is a place to kick up my feet and find work.";
    private string dialogue2_1 = "Straight to the point aye. No greetings, nor nothing.";
    private string dialogue1_2 = "I don't got time for stupid meaningless civilized tradtions.";
    private string dialogue2_2 = "Well names Jerry, and I don't talk to rude wannabe Cowboys.";
    private string dialogue1_3 = "The only thing what will be rude is this barrel agianst your cranium if you don't answer the question.";
    private string dialogue2_3 = "Sorry... their is a tavern all the way down to the left.";
    

    void Update() {
        theDistance = PlayerCasting.distanceFromTarget;
    }

    void OnMouseOver() {
        if (theDistance <= interactDistance) {
            interactTextUI.GetComponent<Text>().text = "Talk";
        }
        if(Input.GetButtonDown("Action") && theDistance <= interactDistance && !talking) {
            StartCoroutine(DialogueWithJerry());
        }
    }

    void OnMouseExit() {
        interactTextUI.GetComponent<Text>().text = "";
    }
    IEnumerator DialogueWithJerry() {
        // Talk to NPC
        talking = true;
        conversationPanelImage.enabled = true;
        
        speakerLabel.text = speaker1;
        convoText.text = dialogue1_1;
        yield return new WaitForSeconds(4);
        
        speakerLabel.text = speaker2;
        convoText.text = dialogue2_1;
        yield return new WaitForSeconds(4);
        
        speakerLabel.text = speaker1;
        convoText.text = dialogue1_2;
        yield return new WaitForSeconds(5);
        
        speakerLabel.text = speaker2;
        convoText.text = dialogue2_2;
        yield return new WaitForSeconds(5);
        
        speakerLabel.text = speaker1;
        convoText.text = dialogue1_3;
        yield return new WaitForSeconds(6);
        
        speakerLabel.text = speaker2;
        convoText.text = dialogue2_3;
        yield return new WaitForSeconds(6);

        // Reset interactions panel
        convoText.text = "";
        speakerLabel.text = "";
        conversationPanelImage.enabled = false;
        talking = false;
    }
}
