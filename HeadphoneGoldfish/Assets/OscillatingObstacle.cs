using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OscillatingObstacle : ObstacleCommon {
    private float centerY;
    public float screenHeight = 5;
    public float span = 2;
    private float startTime;
    public float maxPhaseOffset = Mathf.PI * 2;
    public float oscillationSpeed = 4;

    // Use this for initialization
    void Start()
    {
        centerY = Random.Range(-screenHeight / 2, screenHeight / 2);
        startTime = Random.Range(0, maxPhaseOffset) + Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, Mathf.Sin(Time.time * oscillationSpeed - startTime) * span + centerY, transform.position.z);
    }
}
