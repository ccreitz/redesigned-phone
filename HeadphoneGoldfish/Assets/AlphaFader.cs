using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlphaFader : MonoBehaviour {

    public float beatDuration;
    private SpriteRenderer sRend;
    private MusicController musControl;

    // Use this for initialization
    void Start()
    {
        sRend = GetComponent<SpriteRenderer>();
        musControl = GameObject.Find("MusicControllerContainer").GetComponent<MusicController>();
    }

    // Update is called once per frame
    void Update()
    {
        float factor = 1.0f - (Mathf.Max(Time.time - musControl.lastBeatTime, 0) / beatDuration);
        sRend.color = new Color(1, 1, 1, factor);
    }
}
