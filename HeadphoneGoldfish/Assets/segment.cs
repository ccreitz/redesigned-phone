using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class segment : MonoBehaviour
{
    public static float speed;
    public float clip_threshold;
    private bool is_out_of_bounds;
    public float powerupChance;

    public Transform[] obstacles;
    public Transform powerup;

    // Use this for initialization
    void Start()
    {
        is_out_of_bounds = false;
        Transform toSpawn;
        if (Random.value < powerupChance)
        {
            toSpawn = powerup;
        }
        else
        {
            toSpawn = obstacles[(int)(Random.value * obstacles.Length)];
        }
        Instantiate(toSpawn, transform, false);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(gameObject.GetComponentInParent<spawner>().GetScrollSpeed(), 0, 0) * Time.deltaTime;

        if (transform.position.x < clip_threshold)
        {
            Destroy(gameObject);
            is_out_of_bounds = true;
        }
    }

    public bool IsOutOfBounds()
    {
        return is_out_of_bounds;
    }
}
