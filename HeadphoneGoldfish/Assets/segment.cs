using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class segment : MonoBehaviour
{
    public float clip_threshold;
    private float centerY;
    public float screenHeight;
    public float span;
    private float startTime;
    public float maxPhaseOffset;
    public float speed;

    // Use this for initialization
    void Start()
    {
        centerY = Random.Range(-screenHeight / 2, screenHeight / 2);
        startTime = Random.Range(0, maxPhaseOffset) + Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, Mathf.Sin(Time.time*speed-startTime)*span + centerY, transform.position.z);

        if (transform.position.x < clip_threshold)
        {
            Destroy(gameObject);
        }
    }
}
