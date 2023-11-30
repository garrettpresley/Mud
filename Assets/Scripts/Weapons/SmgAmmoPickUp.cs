using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmgAmmoPickUp : MonoBehaviour
{
    private int boxAmount = 50;
    public AudioSource audioSource;
    void OnTriggerEnter (Collider col) {
        if(col.gameObject.CompareTag("Player")) {
            audioSource.Play();
	        AmmoDisplay.ammoCountSmg += boxAmount;
	        this.gameObject.SetActive(false);
        }
    }
}
