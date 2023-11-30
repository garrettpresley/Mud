using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolAmmoPickUp : MonoBehaviour
{
    private int boxAmount = 25;
    public AudioSource audioSource;
    void OnTriggerEnter (Collider col) {
        if(col.gameObject.CompareTag("Player")) {
            audioSource.Play();
	        AmmoDisplay.ammoCountPistol += boxAmount;
	        this.gameObject.SetActive(false);
        }
    }
}
