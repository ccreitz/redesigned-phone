using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour {
    public Transform segment;
    public float time_between_spawn;
    private float last_spawn_time;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if ((Time.time - last_spawn_time) > time_between_spawn) {
            spawn();
        }
	}

    void spawn()
    {
        GameObject.Instantiate(segment);
        last_spawn_time = Time.time;
    }
}
