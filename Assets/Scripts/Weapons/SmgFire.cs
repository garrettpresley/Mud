using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmgFire : MonoBehaviour
{
    public GameObject mp5k;
    public static bool isFiring = false;
    public static bool fullAuto = false;
    public GameObject muzzleFlash;
    public AudioSource mp5kShot;
    public int burstSize = 5;

    public int DamageAmount = 15;
    public float TargetDistance;
    public float AllowedRange = 50.0f;
    public GameObject TheBlood;

    void Update() {
        if (Input.GetButtonDown("Fire1") && WeaponsEquipped.smgEquipped && !isFiring && AmmoDisplay.ammoCountSmg > 0) {
            // Fire the smg
            fullAuto = true;
            StartCoroutine(FireTheSmg(0.1f));
        }
        if (Input.GetButtonUp("Fire1")) {
            fullAuto = false;
        }
        
    }

    System.Collections.IEnumerator FireTheSmg(float seconds) {
        // Set the smg to firing stage
        isFiring = true;
        // Fire the smg burst amount of times
        for(; fullAuto && AmmoDisplay.ammoCountSmg > 0;) {
            // Fire the gun
            mp5kShot.Play();
            muzzleFlash.SetActive(true);
            mp5k.GetComponent<Animator>().enabled = true;

            // Cause damage to target
            RaycastHit Shot;
            if (Physics.Raycast (transform.position, transform.TransformDirection(Vector3.forward), out      Shot)) {
                TargetDistance = Shot.distance;
                if (TargetDistance < AllowedRange) {
                    Shot.transform.SendMessage("DeductPoints", DamageAmount, SendMessageOptions.     DontRequireReceiver);
                    // Cause blood splatter effect
                    if (Physics.Raycast (transform.position, transform.TransformDirection(Vector3.forward), out Shot)) {
                        if(Shot.transform.tag == "Vampire") {
                            Instantiate(TheBlood, Shot.point, Quaternion.FromToRotation(Vector3.up, Shot.normal));
                        }
                    }
                }
            }

            // Wait for gun to fire
            yield return new WaitForSeconds(seconds);

            // Stop gun from firing
            muzzleFlash.SetActive(false);
            mp5k.GetComponent<Animator>().enabled = false;
            AmmoDisplay.ammoCountSmg--;
        }

        // Unset the smg from firing stage
        isFiring = false;
    }
}
