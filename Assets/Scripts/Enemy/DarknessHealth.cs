using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DarknessHealth : MonoBehaviour {
    public int EnemyHealth = 4000;
    public GameObject theZombie;
    public GameObject vampires;
    public GameObject spiders;
    private bool spawnedMinions;
    public Image conversationPanelImage;
    public Text speakerLabel;
    public Text convoText;
    private string speaker1 = "Mud:";
    private string dialogue1 = "When you get to hell, tell them Mud sent you.";
    

    public void DeductPoints (int DamageAmount) {
        EnemyHealth -= DamageAmount;
    }

    void Update () {
        if (EnemyHealth <= 0) {
            this.GetComponent<DarknessFollow>().enabled = false;
            theZombie.GetComponent<Animation>().Play("Dying");
            StartCoroutine(Dialogue());
            EndZombie();
        }
        if(EnemyHealth <= 2000 && !spawnedMinions) {
            StartCoroutine(SpawnMinions());
        }
    }

    IEnumerator Dialogue() {
        conversationPanelImage.enabled = true;
        speakerLabel.text = speaker1;
        convoText.text = dialogue1;
        yield return new WaitForSeconds(2.5f);
        convoText.text = "";
        speakerLabel.text = "";
        conversationPanelImage.enabled = false;

    }

    void EndZombie() {
        GlobalChecks.defeatedDarkness = true;
        StartCoroutine(WaitAndDestroy(3));
    }

    IEnumerator SpawnMinions() {
        vampires.SetActive(true);
        spiders.SetActive(true);
        spawnedMinions = true;
        yield return new WaitForSeconds (0.1f);
    }

    System.Collections.IEnumerator WaitAndDestroy(float waitTime) {
        yield return new WaitForSeconds(waitTime);
        Destroy(gameObject);
    }

}
