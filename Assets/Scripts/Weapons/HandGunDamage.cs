using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandGunDamage : MonoBehaviour
{
    public int DamageAmount = 14;
    public float TargetDistance;
    public float AllowedRange = 40.0f;
    public GameObject TheBlood;
    public RaycastHit hit;

    void Update () {
        if(Input.GetButtonDown("Fire1") && !PistolFire.isFiring && AmmoDisplay.ammoCountPistol > 0) {
            RaycastHit Shot;
            if (Physics.Raycast (transform.position, transform.TransformDirection(Vector3.forward), out Shot)) {
                TargetDistance = Shot.distance;
                if (TargetDistance < AllowedRange) {
                    Shot.transform.SendMessage("DeductPoints", DamageAmount, SendMessageOptions.DontRequireReceiver);
                    if (Physics.Raycast (transform.position, transform.TransformDirection(Vector3.forward), out Shot)) {
                        if(hit.transform.tag == "Vampire") {
                            Instantiate(TheBlood, hit.point, Quaternion.FromToRotation(Vector3.up, hit.normal));
                        }
                    }
                }
            }
        }
    }
}
