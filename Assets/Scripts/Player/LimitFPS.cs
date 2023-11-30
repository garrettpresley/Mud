using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitFPS : MonoBehaviour {
    // The fps cap
    public int fpsCap = 60;
    
    // Start is called before the first frame update
    void Start() {
        Application.targetFrameRate = fpsCap;
    }
}
