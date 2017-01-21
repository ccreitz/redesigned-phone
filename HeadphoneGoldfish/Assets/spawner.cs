using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour {
    public Transform segment;
    public float time_between_spawn;
    public float scroll_speed;
    public List<Transform> segments;

    private float last_spawn_time;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        float elapsed = (Time.time - last_spawn_time);
        if (elapsed > time_between_spawn/-scroll_speed) {
            spawn();
        }
    }

    void spawn()
    {
        Transform seg = GameObject.Instantiate(segment);
        seg.SetParent(transform);
        last_spawn_time = Time.time;
    }

    public float GetScrollSpeed()
    {
        return scroll_speed;
    }
}
