using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void Damaged()
    {
        Invoke("GotDamaged", 0.3f);
    }
    
    void GotDamaged()
    {
        gameObject.GetComponentInChildren<CapsuleCollider>().enabled = false;
    }
}
