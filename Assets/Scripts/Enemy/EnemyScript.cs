using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {
    public int EnemyHealth = 100;
    public GameObject theZombie;

    public void DeductPoints (int DamageAmount) {
        EnemyHealth -= DamageAmount;
    }

    void Update () {
        if (EnemyHealth <= 0) {
            this.GetComponent<ZombieFollow>().enabled = false;
            theZombie.GetComponent<Animation>().Play("Dying");
            EndZombie();
        }
    }

    void EndZombie() {
        StartCoroutine(WaitAndDestroy(3));
    }

    System.Collections.IEnumerator WaitAndDestroy(float waitTime) {
        yield return new WaitForSeconds(waitTime);
        Destroy(gameObject);
    }

}
