using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour {
    public Transform segment;
    public float time_between_spawn;
    public float scroll_speed_default;
    public List<Transform> segments;
    public float difficulty_change;
    public float powerup_difficulty_change;
    private float scroll_speed;

    private float last_spawn_time;

	// Use this for initialization
	void Start () {
        scroll_speed = scroll_speed_default;
	}

    public void BumpDifficulty()
    {
        time_between_spawn *= difficulty_change;
    }

    public void PowerupBumpDifficulty()
    {
        time_between_spawn *= powerup_difficulty_change;
    }

    // Update is called once per frame
    void Update () {
        scroll_speed = scroll_speed_default - (WaveDetector.Instance.speedFactor * WaveDetector.Instance.Speed);
        float elapsed = (Time.time - last_spawn_time);
        if (elapsed > time_between_spawn/-scroll_speed) {
            spawn();
        }
        
    }

    void spawn()
    {
        Transform seg = GameObject.Instantiate(segment, transform, false);
        last_spawn_time = Time.time;
    }

    public float GetScrollSpeed()
    {
        return scroll_speed;
    }
}
