using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishCharacter : MonoBehaviour {
    public float invTime;
    public Color invColor;
    private float lastInv;

    // Use this for initialization
    void Start () {
        lastInv = Time.time - invTime - 1;
	}
	
	// Update is called once per frame
	void Update () {
        GetComponent<SpriteRenderer>().color = isInv() ? invColor : Color.white;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        lastInv = Time.time;
    }

    private bool isInv()
    {
        return Time.time - lastInv < invTime;
    }
}
