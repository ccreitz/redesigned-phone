using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadBobber : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        int speed = WaveDetector.Instance.Speed;
        transform.gameObject.GetComponent<Animator>().speed = speed + 1f;
    }
}