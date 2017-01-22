using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DartBehavior : ObstacleCommon {
    public float min_delay;
    public float max_delay;
    private float delay;
    public float speed;
    public AudioClip whoosh;
    private bool playedWhoosh = false;

	// Use this for initialization
	override protected void Start () {
        base.Start();
        delay = Random.Range(min_delay, max_delay);
    }
	
	// Update is called once per frame
	void Update () {
        if (delay <= 0)
        {
            if (!playedWhoosh)
            {
                playedWhoosh = true;
                source.clip = whoosh;
                source.Play();
            }
            transform.position = new Vector3(transform.position.x, transform.position.y + Time.deltaTime * speed, 0);
        } else
        {
            delay -= Time.deltaTime;
        }
	}
}
