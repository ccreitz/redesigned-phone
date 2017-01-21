using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class segment : MonoBehaviour
{
    public float clip_threshold;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(-1, 0, 0) * Time.deltaTime;

        if (transform.position.x < clip_threshold)
        {
            Destroy(gameObject);
        }
    }
}
