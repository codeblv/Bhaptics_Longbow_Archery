using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MasterScore : MonoBehaviour {

    private int score;
    private int numArrow;
    private int numHit;
    private int timer;

    // Use this for initialization
    void Start() {
        score = 0;
        numArrow = 0;
        numHit = 0;
    }

    // Update is called once per frame
    void Update() {

    }

    public void scoreIncrease(int k)
    {
        this.score = this.score + k;
    }

    public void numHitIncrease()
    {
        this.numHit = this.numHit + 1;
    }

    public void numArrowIncrease()
    {
        this.numArrow = this.numArrow + 1;
    }

    public int getNumArrow()
    {
        return this.numArrow;
    }

    public int getNumHit()
    {
        return this.numHit;
    }

    public int getScore()
    {
        return this.score;
    }
}
