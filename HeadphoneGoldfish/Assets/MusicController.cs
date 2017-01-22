using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MusicController : MonoBehaviour
{
    FMOD.Studio.EventInstance mx;
    private int lastSpeed = 0;
    public float lastBeatTime;
    public float lastClickTime;
    public float powerupScoreTimeThreshold;

    // Use this for initialization
    void Start()
    {
        //var studio = new FMODUnity.RuntimeManager();
        string x = "event:/MX";

        mx = FMODUnity.RuntimeManager.CreateInstance(x);
        mx.start();
        lastBeatTime = -1000;

        float worldScreenHeight = Camera.main.orthographicSize * 2.0f;
        float worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;
        GetComponent<BoxCollider2D>().size = new Vector3(worldScreenWidth, worldScreenHeight);
    }

    private FMOD.RESULT FmodCallback(FMOD.Studio.EVENT_CALLBACK_TYPE type, IntPtr eventInstance, IntPtr parameters)
    {
        if (this == null)
        {
            Debug.LogError("WTF the callback called on a null object");
            return FMOD.RESULT.ERR_INTERNAL;
        }
        //Debug.Log("Controller Beat!");
        BroadcastMessage("OnBeat", SendMessageOptions.DontRequireReceiver);
        lastBeatTime = Time.time;
        if (lastBeatTime - lastClickTime < powerupScoreTimeThreshold && lastBeatTime > 0)
        {
            GotPowerup();
        }
        return FMOD.RESULT.OK;
    }

    private void OnDestroy()
    {
        mx.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }

    private void OnGUI()
    {
        var myLog = GUI.TextArea(new Rect(50, 10, 50, 20), WaveDetector.Instance.Smoothspeed.ToString("F2"));
    }

    private void OnEnable()
    {
        mx.setPaused(false);
    }

    private void OnDisable()
    {
        mx.setPaused(true);
    }

    void Update()
    {
        mx.setCallback(FmodCallback, FMOD.Studio.EVENT_CALLBACK_TYPE.TIMELINE_BEAT | FMOD.Studio.EVENT_CALLBACK_TYPE.TIMELINE_MARKER);
        /*if (lastSpeed != WaveDetector.Instance.Speed)
        {
            Debug.Log("Changing from " + lastSpeed + " to " + WaveDetector.Instance.Speed);
            lastSpeed = WaveDetector.Instance.Speed;
            mx.setParameterValue("DrumFader", 1);
            mx.setParameterValue("PadFader", 1);
            mx.setParameterValue("SpeedFader", WaveDetector.Instance.Speed + 1);
            
        }*/

        mx.setParameterValue("DrumFader", 1);
        mx.setParameterValue("PadFader", 1);
        mx.setParameterValue("SpeedFader", WaveDetector.Instance.Smoothspeed);


        if (Input.GetMouseButtonDown(0))
        {
            lastClickTime = Time.time;

            if (lastBeatTime > 0)
            {
                if (lastClickTime - lastBeatTime < powerupScoreTimeThreshold)
                {
                    GotPowerup();
                }
                else
                {
                    Debug.Log("Missed!");
                    GameObject.FindGameObjectWithTag("GameController").GetComponent<FishGameController>().SubMult();
                }
            }
        }
    }

    void GotPowerup()
    {
        Collider2D myCollider = GetComponent<Collider2D>();
        foreach (Powerup pwr in GameObject.FindObjectsOfType<Powerup>())
        {
            Collider2D otherCollider = pwr.GetComponent<Collider2D>();
            if (otherCollider.bounds.Intersects(myCollider.bounds))
            {
                Destroy(pwr.gameObject);
                Debug.Log("Got powerup");
                lastBeatTime = -1000;
                lastClickTime = -1000;
                GameObject.FindGameObjectWithTag("GameController").GetComponent<FishGameController>().AddMult();
                break;
            }
        }
    }
}
