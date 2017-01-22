using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteeringObstacle : ObstacleCommon {
    private float centerY;
    public float screenHeight = 5;
    public float span = 2;
    private float startTime;
    public float maxPhaseOffset = Mathf.PI * 2;
    public float oscillationSpeed = 4;

    Rigidbody2D rigid_body;

    // Use this for initialization
    override protected void Start () {
        base.Start();
        centerY = Random.Range(-screenHeight / 2, screenHeight / 2);
        startTime = Random.Range(0, maxPhaseOffset) + Time.time;

        rigid_body = transform.gameObject.GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        rigid_body.AddForce(new Vector2(-0.5f, Mathf.Sin(Time.time * oscillationSpeed - startTime) * span + centerY), ForceMode2D.Force);

        Vector2 velocity = rigid_body.velocity;
        if (velocity.magnitude > 0.1f)
        {
            Vector2 dir = rigid_body.velocity;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward); ;
        }
    }
}
