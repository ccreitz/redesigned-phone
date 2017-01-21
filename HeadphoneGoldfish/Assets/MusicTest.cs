using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicTest : MonoBehaviour {
    public float currspeed;
    FMOD.Studio.EventInstance mx;
    FMOD.Studio.ParameterInstance mxSpeed;

	// Use this for initialization
	void Start () {
        //var studio = new FMODUnity.RuntimeManager();
        string x = "event:/MX";
        //studio.play
        // FMODUnity.RuntimeManager.PlayOneShot(x);
        
        mx = FMODUnity.RuntimeManager.CreateInstance(x);
        mx.getParameter("Speed", out mxSpeed);
        mx.start();
        mxSpeed.setValue(1F);
	}
	
	// Update is called once per frame
	void Update () {
        var res = mx.setParameterValue("Speed", currspeed);
        float x;
        mxSpeed.getValue(out x);
        //Debug.Log(x);		
	}
}
