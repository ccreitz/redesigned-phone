using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class segment : MonoBehaviour
{
    public static float speed;
    public float clip_threshold;
    private bool is_out_of_bounds;
    private float centerY;
    public float screenHeight;
    public float span;
    private float startTime;
    public float maxPhaseOffset;

    // Use this for initialization
    void Start()
    {
        centerY = Random.Range(-screenHeight / 2, screenHeight / 2);
        startTime = Random.Range(0, maxPhaseOffset) + Time.time;
        is_out_of_bounds = false;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, Mathf.Sin(Time.time * speed - startTime) * span + centerY, transform.position.z);
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
