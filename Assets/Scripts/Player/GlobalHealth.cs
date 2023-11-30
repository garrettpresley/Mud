// Codde from Jimmy Vegas Unity Tutorial
// These scripts will manage your health and updated AI
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class GlobalHealth : MonoBehaviour {

	public static int PlayerHealth = 100;
	public int InternalHealth;
	public GameObject HealthText;

	void Update () {
		InternalHealth = PlayerHealth;
		HealthText.GetComponent<Text> ().text = "Health: " + PlayerHealth + "%";
		if (PlayerHealth <= 0) {
			SceneManager.LoadScene (1);
		}
	}
}
