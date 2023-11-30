using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolFire : MonoBehaviour {
    public GameObject blackPistol;
    public static bool isFiring = false;
    public GameObject muzzleFlash;
    public AudioSource pistolShot;

    public int DamageAmount = 14;
    public float TargetDistance;
    public float AllowedRange = 40.0f;
    public GameObject TheBlood;

    void Update() {
        if(Input.GetButtonDown("Fire1") && WeaponsEquipped.pistolEquipped && !isFiring && AmmoDisplay.ammoCountPistol > 0) {
            // Start animation
            StartCoroutine(FireThePistol());

            // Cause damage to target if within range
            RaycastHit Shot;
            if (Physics.Raycast (transform.position, transform.TransformDirection(Vector3.forward), out Shot)) {
                TargetDistance = Shot.distance;
                if (TargetDistance < AllowedRange) {
                    Shot.transform.SendMessage("DeductPoints", DamageAmount, SendMessageOptions.DontRequireReceiver);
                    // Cause blood splatter effect
                    if (Physics.Raycast (transform.position, transform.TransformDirection(Vector3.forward), out Shot)) {
                        if(Shot.transform.tag == "Vampire") {
                            Instantiate(TheBlood, Shot.point, Quaternion.FromToRotation(Vector3.up, Shot.normal));
                        }
                    }

                }
            }

            // Decrement ammo
            AmmoDisplay.ammoCountPistol--;
        }
    }

    IEnumerator FireThePistol() {
        isFiring = true;
        blackPistol.GetComponent<Animator>().Play("FirePistol");
        muzzleFlash.SetActive(true);
        pistolShot.Play();
        yield return new WaitForSeconds(0.05f);
        muzzleFlash.SetActive(false);
        yield return new WaitForSeconds(0.2f);
        blackPistol.GetComponent<Animator>().Play("Standard");
        isFiring = false;
    }
}
