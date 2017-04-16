using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MusicController : MonoBehaviour
{
    //FMOD.Studio.EventInstance mx;
    private int lastSpeed = 0;
    public float lastBeatTime;
    public float lastClickTime;
    public float powerupScoreTimeThreshold;
    private float lastMusTime;
    private float musFreq;
    public float musFadeDur = 1;
    private float lastMixA;
    private float targetMixA;
    private float lastMixB;
    private float targetMixB;

    // Use this for initialization
    void Start()
    {
        //var studio = new FMODUnity.RuntimeManager();
//        string x = "event:/MX";
//
//        mx = FMODUnity.RuntimeManager.CreateInstance(x);
//        mx.setVolume(1.5f);
//        mx.start();
//        lastBeatTime = -1000;
//
//        float worldScreenHeight = Camera.main.orthographicSize * 2.0f;
//        float worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;
//        GetComponent<BoxCollider2D>().size = new Vector3(worldScreenWidth, worldScreenHeight);
//
//        musFreq = UnityEngine.Random.Range(4, 10);
//        Debug.Log("Chose next switch in seconds " + musFreq.ToString());
//        if (UnityEngine.Random.value < 0.5)
//        {
//            targetMixA = UnityEngine.Random.value;
//            targetMixB = 1;
//        }
//        else
//        {
//            targetMixB = UnityEngine.Random.value;
//            targetMixA = 1;
//        }
//        lastMixA = targetMixA;
//        lastMixB = targetMixB;
//        mx.setParameterValue("DrumFader", targetMixA);
//        mx.setParameterValue("PadFader", targetMixB);
//        mx.setParameterValue("SpeedFader", WaveDetector.Instance.Smoothspeed + 1);
//        lastMusTime = Time.time;
    }

//    private FMOD.RESULT FmodCallback(FMOD.Studio.EVENT_CALLBACK_TYPE type, IntPtr eventInstance, IntPtr parameters)
//    {
//        if (this == null)
//        {
//            Debug.LogError("WTF the callback called on a null object");
//            return FMOD.RESULT.ERR_INTERNAL;
//        }
//        //Debug.Log("Controller Beat!");
//        BroadcastMessage("OnBeat", SendMessageOptions.DontRequireReceiver);
//        lastBeatTime = Time.time;
//        if (lastBeatTime - lastClickTime < powerupScoreTimeThreshold && lastBeatTime > 0)
//        {
//            GotPowerup();
//        }
//        return FMOD.RESULT.OK;
//    }

    private void OnDestroy()
    {
//        mx.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }

    private void OnGUI()
    {
        //var myLog = GUI.TextArea(new Rect(50, 10, 50, 20), WaveDetector.Instance.Smoothspeed.ToString("F2"));
    }

    public void Unpause()
    {
//        if (mx != null) mx.setPaused(false);
    }

    private void OnEnable()
    {
        Unpause();
    }

    public void Pause()
    {
//        if (mx != null) mx.setPaused(true);
    }

    private void OnDisable()
    {
        Pause();
    }

    void Update()
    {
////        mx.setCallback(FmodCallback, FMOD.Studio.EVENT_CALLBACK_TYPE.TIMELINE_BEAT | FMOD.Studio.EVENT_CALLBACK_TYPE.TIMELINE_MARKER);
//        /*if (lastSpeed != WaveDetector.Instance.Speed)
//        {
//            Debug.Log("Changing from " + lastSpeed + " to " + WaveDetector.Instance.Speed);
//            lastSpeed = WaveDetector.Instance.Speed;
//            mx.setParameterValue("DrumFader", 1);
//            mx.setParameterValue("PadFader", 1);
//            mx.setParameterValue("SpeedFader", WaveDetector.Instance.Speed + 1);
//            
//        }*/
//        float elapsed = Time.time - lastMusTime;
//        
//        if (elapsed > musFreq)
//        {
//            if (elapsed > musFreq + musFadeDur)
//            {
//                Debug.Log("Switching to next phase");
//                lastMusTime = Time.time;
//                musFreq = UnityEngine.Random.Range(4, 10);
//                Debug.Log("Chose next switch in seconds " + musFreq.ToString());
//                lastMixA = targetMixA;
//                lastMixB = targetMixB;
//                if (UnityEngine.Random.value < 0.5)
//                {
//                    targetMixA = UnityEngine.Random.value;
//                    targetMixB = 1;
//                }
//                else
//                {
//                    targetMixB = UnityEngine.Random.value;
//                    targetMixA = 1;
//                }
//            }
//            else
//            {
//                float mixA = Mathf.Lerp(lastMixA, targetMixA, (elapsed - musFreq) / musFadeDur);
//                float mixB = Mathf.Lerp(lastMixB, targetMixB, (elapsed - musFreq) / musFadeDur);
//                Debug.Log("Current mixA: " + mixA.ToString() + " mixB: " + mixB.ToString());
//                mx.setParameterValue("DrumFader", Mathf.Max(mixA, 0.1f));
//                mx.setParameterValue("PadFader", mixB);
//                mx.setParameterValue("SpeedFader", WaveDetector.Instance.Smoothspeed + 1);
//            }
//        }
//
//        if (Input.GetMouseButtonDown(0))
//        {
//            lastClickTime = Time.time;
//
//            if (lastBeatTime > 0)
//            {
//                if (lastClickTime - lastBeatTime < powerupScoreTimeThreshold)
//                {
//                    GotPowerup();
//                }
//                else
//                {
//                    Debug.Log("Missed!");
//                    GameObject.FindGameObjectWithTag("GameController").GetComponent<FishGameController>().SubMult();
//                }
//            }
//        }
//
//        // Eel obstacle music
//
//        GameObject[] segs = GameObject.FindGameObjectsWithTag("Scoring");
//        //        Debug.Log(segs.Length);
//        fadeObstacleMusic(segs, "Eel(Clone)", "EelFader");
//        fadeObstacleMusic(segs, "Seaweed(Clone)", "SeaweedFader");
//        fadeObstacleMusic(segs, "FishHook(Clone)", "HookFader");
//        fadeObstacleMusic(segs, "Jellyfish(Clone)", "JellyfishFader");


    }

    void fadeObstacleMusic(GameObject[] all_segs, string obstacle_name, string fader_name)
    {
        List<GameObject> segments = new List<GameObject>();

        foreach (GameObject segment in all_segs)
        {
            //Debug.Log(segment.transform.childCount);
            if (segment == null || segment.transform == null)
            {
                continue;
            }
            if (segment.transform.childCount == 0)
            {
                continue;
            }
            Transform obstacle = segment.transform.GetChild(0);
            if (obstacle == null)
            {
                continue;
            }
            if (obstacle.name == obstacle_name)
            {
                segments.Add(segment);
            }
        }

        float distance = getDistanceToClosest(segments);
        //Debug.Log("Distance to eel: " + distance);
        if (distance < 10)
        {
//            mx.setParameterValue(fader_name, 1.5f - distance / 10 + 0.5f);
        }
        else
        {
//            mx.setParameterValue(fader_name, 0);
        }
    }

    float getDistanceToClosest(List<GameObject> segments)
    {
        float min = float.MaxValue;
        foreach (GameObject seg in segments) {
            if (seg == null)
            {
                continue;
            }
            float dist = Vector3.Distance(Vector3.zero, seg.transform.position);
            if (dist < min)
            {
                min = dist;
            }
        }
        return min;
    }

    public void GotPowerup()
    {
        Debug.Log("GETS HERE");
        // Collider2D myCollider = GetComponent<Collider2D>();
        foreach (Powerup pwr in GameObject.FindObjectsOfType<Powerup>())
        {
        //     Collider2D otherCollider = pwr.GetComponent<Collider2D>();
        //     if (otherCollider.bounds.Intersects(myCollider.bounds))
        //     {
                GetComponent<AudioSource>().Play();
                Destroy(pwr.gameObject);
                Debug.Log("Got powerup");
                // lastBeatTime = -1000;
                // lastClickTime = -1000;
                
                GameObject.FindGameObjectWithTag("GameController").GetComponent<FishGameController>().AddMult();
                GameObject.Find("SpawnerObject").GetComponent<spawner>().BumpDifficulty();
                break;
        //     }
        }
    }
}
