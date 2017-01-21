using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour {
    public GameObject spriteObjTemplate;
    public float scroll_speed_default;
    public float parallaxSpeed;

    private float worldScreenWidth;
    private float worldScreenHeight;
    private float spriteWidth;
    private float spriteHeight;
    private float spriteScale;
    private float scaledSpriteWidth;

    void Start () {
        Sprite sprite = spriteObjTemplate.GetComponent<SpriteRenderer>().sprite;
        spriteWidth = sprite.bounds.size.x;
        spriteHeight = sprite.bounds.size.y;

        worldScreenHeight = Camera.main.orthographicSize * 2.0f;
        worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;
        spriteScale = worldScreenHeight / spriteHeight;
        scaledSpriteWidth = spriteWidth * spriteScale;
    }
	
	void Update () {
        foreach (Transform child in GetComponentsInChildren<Transform>())
        {
            if (child == transform)
            {
                continue;
            }
            if (child.position.x < (worldScreenWidth * 0.5f) - (scaledSpriteWidth * 0.5f) && transform.childCount <= 1)
            {
                GameObject newObj = Instantiate<GameObject>(spriteObjTemplate, new Vector3((worldScreenWidth * 0.5f) + (scaledSpriteWidth * 0.5f), 0.0f, 10.0f), new Quaternion(), transform);
                newObj.transform.localScale = new Vector3(spriteScale, spriteScale, 1.0f);
            }
            else if (child.position.x < (worldScreenWidth * -0.5f) + (scaledSpriteWidth * -0.5f))
            {
                Destroy(child.gameObject);
            }
        }
        if (transform.childCount == 0)
        {
            GameObject newObj = Instantiate<GameObject>(spriteObjTemplate, new Vector3(0.0f, 0.0f, 10.0f), new Quaternion(), transform);
            newObj.transform.localScale = new Vector3(spriteScale, spriteScale, 1.0f);
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
}
