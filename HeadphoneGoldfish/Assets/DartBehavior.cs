using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DartBehavior : MonoBehaviour {

    public float min_delay;
    public float max_delay;
    private float delay;
    public float speed;

	// Use this for initialization
	void Start () {
        delay = Random.Range(min_delay, max_delay);
	}
	
	// Update is called once per frame
	void Update () {
        if (delay <= 0)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + Time.deltaTime * speed, 0);
        } else
        {
            delay -= Time.deltaTime;
        }
	}
}
