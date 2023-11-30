using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScriptSpider : MonoBehaviour {
    public int EnemyHealth = 30;
    public GameObject theSpider;

    public void DeductPoints (int DamageAmount) {
        EnemyHealth -= DamageAmount;
    }

    void Update () {
        if (EnemyHealth <= 0) {
            this.GetComponent<SpiderFollow>().enabled = false;
            theSpider.GetComponent<Animation>().Play("die");
            EnemyHealth = 1;
            EndSpider();
        }
    }

    void EndSpider() {
        StartCoroutine(WaitAndDestroy(1f));
    }

    System.Collections.IEnumerator WaitAndDestroy(float waitTime) {
        yield return new WaitForSeconds(waitTime);
        Destroy(gameObject);
    }

}
