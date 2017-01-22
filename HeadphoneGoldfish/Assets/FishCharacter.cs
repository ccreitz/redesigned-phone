using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishCharacter : MonoBehaviour {
    public float invTime;
    public Color invColor;
    private float lastInv;
    public float blinkSpeed;

    // Use this for initialization
    void Start () {
        lastInv = Time.time - invTime - 1;
	}
	
	// Update is called once per frame
	void Update () {
        GetComponent<SpriteRenderer>().color = (isInv() && ((Time.time%blinkSpeed) < blinkSpeed/2)) ? invColor : Color.white;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Damaging"))
        {
            lastInv = Time.time;
            GameObject.FindGameObjectWithTag("GameController").GetComponent<FishGameController>().Damaged();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Scoring"))
        {
            GameObject.FindGameObjectWithTag("GameController").GetComponent<FishGameController>().AddScore();
        }
    }

    private bool isInv()
    {
        return Time.time - lastInv < invTime;
    }
}
