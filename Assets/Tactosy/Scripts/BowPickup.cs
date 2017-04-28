using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowPickup : MonoBehaviour {
    public GameObject tactosyPlayer;

    // Use this for initialization
    void Start()
    {
        tactosyPlayer.SendMessage("BowPickup");
    }
}
