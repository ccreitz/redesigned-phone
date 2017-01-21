using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WaveDetector : MonoBehaviour
{
    public int threshold;
    public enum Tailstate { None, Left, Right };
    private Tailstate state;
    private float elapsed;
    public int memsize;
    public float[] buckets = new float[] { };
    private int speed;
    public float speedDecayTime;
    private static WaveDetector instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

        // Use this for initialization
        void Start()
    {
       // Debug.Log("buckets " + buckets.Length);
    }

    public static WaveDetector Instance
    {
        get { return instance; }
    }

    public int Speed
    {
        get { return speed; }
    }

    public Tailstate State
    {
        get { return state; }
    }
    // Update is called once per frame
    void OnGUI()
    {
        var myLog = GUI.TextArea(new Rect(10, 10, 50, 20), speed + " " + state.ToString());
    }
    void Update()
    {
        float dx = Input.GetAxis("Mouse X");
        elapsed += Time.deltaTime;
        if (elapsed > speedDecayTime)
        {
            if (speed > 0)
            {
                speed--;
            }
            elapsed = 0;
        }
        //Debug.Log(state.ToString() + speed);
        if (dx > threshold)
        {
            //tail right
            if (state == Tailstate.Right)
            {
                //Do nothing, Stay in State
            }
            else if (state == Tailstate.Left || state == Tailstate.None)
            {
                state = Tailstate.Right;
            }
        }
        else if (dx < -threshold)
        {
            //tail left
            if (state == Tailstate.Left)
            {
                //Do Nothing
            }
            else if (state == Tailstate.Right || state == Tailstate.None)
            {
                state = Tailstate.Left;
                Tailbeat(elapsed);
                elapsed = 0;
            }
        }
        else
        {
            //No big enough input
        }
    }
    private void Tailbeat(float elapsed)
    {
        CircularBuffer<float> buff = new CircularBuffer<float>(memsize);
        buff.Add(elapsed);
        float sum = 0F;
        foreach(float t in buff)
        {
            sum += t;
        }
        float average = sum / memsize;
        // Debug.Log(average);
        for (int i = 0; i < buckets.Length; i++)
        {
            if (average <= buckets[i])
            {
                speed = buckets.Length - i;
                break;
            }
        }
        if (average > buckets[buckets.Length - 1])
        {
            speed = 0;
        }
        average = 0;
    }
}
