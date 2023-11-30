using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTrigger : MonoBehaviour
{
    public GameObject boss;
    public GameObject vampires;
    public GameObject spiders;

    void OnTriggerEnter (Collider col) {
        if(col.gameObject.CompareTag("Player")) {
            StartCoroutine(SummonEnemies());
	        this.gameObject.SetActive(false);
        }
    }

    IEnumerator SummonEnemies() {
        boss.SetActive(true);
        vampires.SetActive(true);
        spiders.SetActive(true);
        yield return new WaitForSeconds(0.1f);
    }
}