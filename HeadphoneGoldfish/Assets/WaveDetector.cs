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
    private float currspeed;
    private int targetspeed;
    public float easefactor;
    public float speedDecayTime;
    private static WaveDetector instance;

    public float speedFactor;

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
        get { return Mathf.RoundToInt(currspeed); }
    }

    public float Smoothspeed
    {
        get { return currspeed; }
    }

    public Tailstate State
    {
        get { return state; }
    }
    // Update is called once per frame
    void OnGUI()
    {
        //var myLog = GUI.TextArea(new Rect(10, 10, 50, 20), targetspeed + " " + state.ToString());
    }
    void Update()
    {
        float dx = Input.GetAxis("Mouse X");
        elapsed += Time.deltaTime;
        if (targetspeed > currspeed && (targetspeed - currspeed) > (easefactor / 2) - .005F)
        {
            currspeed = currspeed + ((targetspeed - currspeed) * easefactor * Time.deltaTime);
        }
        else if (targetspeed < currspeed && (currspeed - targetspeed) > (easefactor / 2) - .005F)
        {
            currspeed = currspeed - ((currspeed - targetspeed) * easefactor * Time.deltaTime);
        }
        if (elapsed > speedDecayTime)
        {
            if (targetspeed > 0)
            {
                targetspeed--;
            }
            elapsed = 0;
        }
        //Debug.Log(dx.ToString("F2") + " Threshold = " + threshold);
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
                Tailbeat(elapsed);
                elapsed = 0;
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
            //Debug.Log(t);
            sum += t;
        }
        float average = sum / memsize;
        //Debug.Log("Average = " + average.ToString("F2") + " Sum = " + sum.ToString("F2") + " Memsize = " + memsize);

        targetspeed = quantizeByBucket(average);
        average = 0;
    }

    private int quantizeByBucket(float x)
    {
        int retval = 0;
        if (x > buckets[buckets.Length - 1])
        {
            retval = 0;
        }
        else
        {
            for (int i = 0; i < buckets.Length; i++)
            {
                if (x <= buckets[i])
                {
                    retval = buckets.Length - i;
                    break;
                }
            }
        }
        Debug.Log("x = " + x.ToString("F2") + " Retval = " + retval);
        return retval;
    }
}
