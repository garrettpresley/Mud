using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedkitPickUp : MonoBehaviour {
    // The health amount cap
    private int healthAmount = 25;
    // The audio source
    public AudioSource audioSource;
    void OnTriggerEnter (Collider col) {
        // Determine if it was the player
         if(col.gameObject.CompareTag("Player")) {
        // Determine the healing amount
        int healingAmount = 100 - GlobalHealth.PlayerHealth;
        if(healingAmount > healthAmount)
            healingAmount = healthAmount;

        // Check if player needs to be healed
        if(healingAmount == 0)
            return;

        // Play audio source
        audioSource.Play();

        // Heal player    
	    GlobalHealth.PlayerHealth += healingAmount;

        // Set object to be un active
	    this.gameObject.SetActive(false);
        }
    }
}
