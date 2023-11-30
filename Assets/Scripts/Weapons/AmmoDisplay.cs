using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoDisplay : MonoBehaviour {
    public GameObject pistolAmmoTextUI;
    public GameObject smgAmmoTextUI;
    public static int ammoCountPistol;
    public static int ammoCountSmg;
    

    void Update() {
        pistolAmmoTextUI.GetComponent<Text>().text = "" + ammoCountPistol;
        smgAmmoTextUI.GetComponent<Text>().text = "" + ammoCountSmg;
    }
}
