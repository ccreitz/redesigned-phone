using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseControl : MonoBehaviour
{
    public float sensitivity;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (WaveDetector.Instance.Smoothspeed > 1 && transform.position.y + WaveDetector.Instance.Smoothspeed * .25f * sensitivity * Time.deltaTime < 4.5f)
        {
            if (transform.position.y + WaveDetector.Instance.Smoothspeed * .25f * sensitivity * Time.deltaTime > 4f)
            {
                transform.position += new Vector3(0, 0, 0);
            }
            else
            {
                transform.position += new Vector3(0, WaveDetector.Instance.Smoothspeed * .25f, 0) * sensitivity * Time.deltaTime;
            }
        }
        else if (transform.position.y > -3.5f && transform.position.y < 4.0f)
        {
            transform.position += new Vector3(0, -.5f * sensitivity * Time.deltaTime, 0);
        }
    }
}
