using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayerToTown : MonoBehaviour {
    public CharacterController thePlayer;
    public Transform theTarget;
    void OnTriggerEnter (Collider col) {
        thePlayer.enabled = false;
        thePlayer.transform.position = theTarget.position;
        thePlayer.enabled = true;
    }
}
