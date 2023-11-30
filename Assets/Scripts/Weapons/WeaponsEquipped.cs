using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsEquipped : MonoBehaviour
{   
    // Booleans to check which weapon is equipped, intially when the game starts up the player will have pistol equipped
    public static bool pistolEquipped = true;
    public static bool smgEquipped = false;

    // The game objects that need to be worked with
    public GameObject thePistol;
    public GameObject theSmg;

    // Check to see if player is switching weapons
    void Update() {
        // Only switch when neither weapon is firing
        if(!PistolFire.isFiring && !SmgFire.isFiring) {
            // Equip the pistol by pressing '1'
            if(Input.GetButtonDown("SwitchPistol")) {
                // Unequip the smg
                theSmg.SetActive(false);
                smgEquipped = false;
                // Equip the pistol
                thePistol.SetActive(true);
                pistolEquipped = true;
            }
            // Equip the smg by pressing '2'
            else if(Input.GetButtonDown("SwitchSmg") && GlobalChecks.gotSmg) {
                // Unequip the pistol
                thePistol.SetActive(false);
                pistolEquipped = false;
                // Equip the smg
                theSmg.SetActive(true);
                smgEquipped = true;
            }
        }
    }
}
