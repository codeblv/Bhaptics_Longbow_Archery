using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneManager1 : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Invoke("SceneChange", 4.0f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void SceneChange()
    {
        SceneManager.LoadScene("MainGame");
    }
}
