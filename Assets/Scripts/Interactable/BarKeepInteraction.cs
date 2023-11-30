using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class BarKeepInteraction : MonoBehaviour {
  public GameObject supplyDrop;
  public GameObject smgItems;
    public GameObject interactTextUI;
    private float theDistance;
    private float interactDistance = 3;
    private bool talking;
    public GameObject npc;
    public Image conversationPanelImage;
    public Text speakerLabel;
    public Text convoText;
  private string speaker1 = "Mud:";
	private string speaker2 = "Barkeep:";
	private string dialogue2_1 = "Hey Cowboy! What should I call you?";
	private string dialogue1_1 = "Never had me a name.";
	private string dialogue2_2 = "You've got to have a name.";
	private string dialogue1_2 = "You can call me Mud.";
	private string dialogue2_3 = "Ominous, it fits your look as well. Well, what can I do you for, Mud?";
	private string dialogue1_3 = "Looking for some work, then a place to rest.";
	private string dialogue2_4 = "We do have some nasty vampires run by a leader named Darkness that took over the old power plant down the road.";
	private string dialogue2_5 = "They're scaring folks, and well, that's bad for business. If you deal with them, you'll get a free room and some coin.";
	private string dialogue2_6 = "Also, I'll give you a bottle of whiskey out of my own pocket, sort of an extra bonus.";
	private string dialogue2_7 = "You do look like the type of man that prefers whiskey.";
	private string dialogue1_4 = "Read me like a book. I'll look into this nasty business for you.";
	private string dialogue2_8 = "Thank you, 'hun. One thing, I need you to retrieve a 'misplaced' SMG in the forest across from this building.";
	private string dialogue2_9 = "Once you do that, come back to me. Once back, I will give you a key to enter the power plant.";
	private string dialogue1_5 = "Ok. What's the deal with the SMG?";
	private string dialogue2_10 = "I need it for some 'personal' affairs. I'll let you use it for the duration of the job, though, if that's what you're asking.";
	private string dialogue2_11 = "And do be careful, some of those unsavory vampire types have wandered into the forest.";
	private string dialogue1_6 = "I usually attract the unsavory ones.";
	private string dialogue2_12 = "Also, please don't die. To be sure of that here is some ammo.";
  private string dialogue2_13 = "Nice job Mud! Heres that whiskey!";
  private string dialogue1_7 = "Thanks, I'm going to enjoy this.";

		
    
    

    void Update() {
        theDistance = PlayerCasting.distanceFromTarget;
    }

    void OnMouseOver() {
        if (theDistance <= interactDistance) {
            interactTextUI.GetComponent<Text>().text = "Barkeep";
        }
        if(Input.GetButtonDown("Action") && theDistance <= interactDistance && !talking) {
					if(GlobalChecks.defeatedDarkness)
            StartCoroutine(DialogueCompletedQuest());
          else {
            if(!GlobalChecks.gotSmg)
              StartCoroutine(DialogueWithoutSmg());
            else 
						  StartCoroutine(DialogueWithSmg());
          }

        }
    }

    void OnMouseExit() {
        interactTextUI.GetComponent<Text>().text = "";
    }
    IEnumerator DialogueWithSmg() {
        talking = true;
        conversationPanelImage.enabled = true;
        speakerLabel.text = speaker2;
        convoText.text = "Here is the key Cowboy! My boys just dropped you a supply drop down the road.";
        supplyDrop.SetActive(true);
        yield return new WaitForSeconds(5);
        convoText.text = "";
        speakerLabel.text = "";
        conversationPanelImage.enabled = false;
        talking = false;
        GlobalChecks.gotKeyToPowerPlant = true;
    }

		IEnumerator DialogueWithoutSmg() {
        talking = true;
        conversationPanelImage.enabled = true;
        
				speakerLabel.text = speaker2;
        convoText.text = dialogue2_1;
        yield return new WaitForSeconds(5);
				
				speakerLabel.text = speaker1;
        convoText.text = dialogue1_1;
        yield return new WaitForSeconds(5);
				
				speakerLabel.text = speaker2;
        convoText.text = dialogue2_2;
        yield return new WaitForSeconds(5);
				
				speakerLabel.text = speaker1;
        convoText.text = dialogue1_2;
        yield return new WaitForSeconds(5);
				
				speakerLabel.text = speaker2;
        convoText.text = dialogue2_3;
        yield return new WaitForSeconds(7);
				
				speakerLabel.text = speaker1;
        convoText.text = dialogue1_3;
        yield return new WaitForSeconds(5);
				
				speakerLabel.text = speaker2;
        convoText.text = dialogue2_4;
        yield return new WaitForSeconds(7);
        
				convoText.text = dialogue2_5;
        yield return new WaitForSeconds(7);
        
				convoText.text = dialogue2_6;
        yield return new WaitForSeconds(7);
        
				convoText.text = dialogue2_7;
        yield return new WaitForSeconds(7);
				
				speakerLabel.text = speaker1;
        convoText.text = dialogue1_4;
        yield return new WaitForSeconds(7);
				
				speakerLabel.text = speaker2;
        convoText.text = dialogue2_8;
        yield return new WaitForSeconds(7);
        
				convoText.text = dialogue2_9;
        yield return new WaitForSeconds(7);
				
				speakerLabel.text = speaker1;
        convoText.text = dialogue1_5;
        yield return new WaitForSeconds(4);
				
				speakerLabel.text = speaker2;
        convoText.text = dialogue2_10;
        yield return new WaitForSeconds(7);
        
				convoText.text = dialogue2_11;
        yield return new WaitForSeconds(7);

				speakerLabel.text = speaker1;
        convoText.text = dialogue1_6;
        yield return new WaitForSeconds(5);

				speakerLabel.text = speaker2;
        convoText.text = dialogue2_12;
        yield return new WaitForSeconds(5);

        smgItems.SetActive(true);
		
				// Reset the conversation panels
        convoText.text = "";
        speakerLabel.text = "";
        conversationPanelImage.enabled = false;
        talking = false;
    }

    IEnumerator DialogueCompletedQuest() {
        talking = true;
        conversationPanelImage.enabled = true;

        speakerLabel.text = speaker2;
        convoText.text = dialogue2_13;
        yield return new WaitForSeconds(5);
				
				speakerLabel.text = speaker1;
        convoText.text = dialogue1_7;
        yield return new WaitForSeconds(5);

        convoText.text = "";
        speakerLabel.text = "";
        conversationPanelImage.enabled = false;
        talking = false;
        GlobalChecks.gotKeyToPowerPlant = true;

        SceneManager.LoadScene(3);
    }
}