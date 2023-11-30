using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRoadToTown : MonoBehaviour
{
    public GameObject vampires;
    public GameObject spiders;

    void OnTriggerEnter (Collider col) {
        if(col.gameObject.CompareTag("Player")) {
            StartCoroutine(SummonEnemies());
	        this.gameObject.SetActive(false);
        }
    }

    IEnumerator SummonEnemies() {
        vampires.SetActive(true);
        spiders.SetActive(true);
        yield return new WaitForSeconds(0.1f);
    }
}
