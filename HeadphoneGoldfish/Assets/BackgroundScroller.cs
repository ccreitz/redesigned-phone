﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour {
    public GameObject spriteObjTemplate;
    public Sprite[] sprites;
    public float scroll_speed_default;
    public float parallaxSpeed;

    private float worldScreenWidth;
    private float worldScreenHeight;
    private float spriteWidth;
    private float spriteHeight;
    private float spriteScale;
    private float scaledSpriteWidth;
    private int lastSpriteIndex = 0;

    void Start () {
        spriteWidth = sprites[0].bounds.size.x;
        spriteHeight = sprites[0].bounds.size.y;

        worldScreenHeight = Camera.main.orthographicSize * 2.0f;
        worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;
        spriteScale = worldScreenHeight / spriteHeight;
        scaledSpriteWidth = spriteWidth * spriteScale;

        SpawnBackground((worldScreenWidth * 0.5f) + (scaledSpriteWidth * -1.5f));
        SpawnBackground((worldScreenWidth * 0.5f) + (scaledSpriteWidth * -0.5f));
    }

    void Update () {
        foreach (Transform child in GetComponentsInChildren<Transform>())
        {
            if (child == transform)
            {
                continue;
            }
            if (child.position.x < (worldScreenWidth * 0.5f) - (scaledSpriteWidth * 0.5f) && transform.childCount <= 2)
            {
                SpawnBackground((worldScreenWidth * 0.5f) + (scaledSpriteWidth * 0.5f));
            }
            else if (child.position.x < (worldScreenWidth * -0.5f) + (scaledSpriteWidth * -0.5f))
            {
                Destroy(child.gameObject);
            }
        }
        foreach (Transform child in GetComponentsInChildren<Transform>())
        {
            if (child == transform)
            {
                continue;
            }
            child.position += new Vector3(parallaxSpeed * (scroll_speed_default - WaveDetector.Instance.Speed), 0.0f, 0.0f) * Time.deltaTime;
        }
    }

    void SpawnBackground(float xPos)
    {
        GameObject newObj = Instantiate<GameObject>(spriteObjTemplate, new Vector3(xPos, 0.0f, 10.0f), new Quaternion(), transform);
        newObj.GetComponent<SpriteRenderer>().sprite = sprites[lastSpriteIndex];
        lastSpriteIndex++;
        if (lastSpriteIndex >= sprites.Length)
        {
            lastSpriteIndex = 0;
        }
        newObj.transform.localScale = new Vector3(spriteScale, spriteScale, 1.0f);
    }
}
