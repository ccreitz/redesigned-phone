using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour {
    FMOD.Studio.EventInstance mx;
    private int lastSpeed = 0;
    // Use this for initialization
    void Start()
    {
        //var studio = new FMODUnity.RuntimeManager();
        string x = "event:/MX";

        mx = FMODUnity.RuntimeManager.CreateInstance(x);
        mx.start();
    }

    private void OnDestroy()
    {
        mx.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }

    // Update is called once per frame
    void Update()
    {
        if (lastSpeed != WaveDetector.Instance.Speed)
        {
            Debug.Log("Changing from " + lastSpeed + " to " + WaveDetector.Instance.Speed);
            lastSpeed = WaveDetector.Instance.Speed;
            mx.setParameterValue("Speed", WaveDetector.Instance.Speed);

        }
        	
    }
}
