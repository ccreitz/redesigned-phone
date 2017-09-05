using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
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

    public GameObject last_sprite;

    void Start()
    {
        spriteWidth = sprites[0].bounds.size.x;
        spriteHeight = sprites[0].bounds.size.y;

        worldScreenHeight = Camera.main.orthographicSize * 2.0f;
        worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;
        spriteScale = worldScreenHeight / spriteHeight;
        scaledSpriteWidth = spriteWidth * spriteScale;

        SpawnBackground((worldScreenWidth * 0.5f) + (scaledSpriteWidth * -2.5f));
        SpawnBackground((worldScreenWidth * 0.5f) + (scaledSpriteWidth * -1.5f));
        last_sprite = SpawnBackground((worldScreenWidth * 0.5f) + (scaledSpriteWidth * -0.5f));
    }

    void Update()
    {
        foreach (Transform child in GetComponentsInChildren<Transform>())
        {
            if (child == transform)
            {
                continue;
            }
            if (child.position.x < (worldScreenWidth * 0.5f) - (scaledSpriteWidth * 0.5f) && transform.childCount <= 3)
            {
                last_sprite = SpawnBackground(last_sprite.transform.position.x + scaledSpriteWidth);
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
			child.position += new Vector3 (parallaxSpeed * (scroll_speed_default - WaveDetector.Instance.Speed * WaveDetector.Instance.speedFactor), 0.0f, 0.0f) * Time.deltaTime;
        }
    }

    GameObject SpawnBackground(float xPos)
    {
        GameObject newObj = Instantiate<GameObject>(spriteObjTemplate, new Vector3(xPos, transform.position.y, transform.position.z), new Quaternion(), transform);
        newObj.GetComponent<SpriteRenderer>().sprite = sprites[lastSpriteIndex];
        lastSpriteIndex++;
        if (lastSpriteIndex >= sprites.Length)
        {
            lastSpriteIndex = 0;
        }
        newObj.transform.localScale = new Vector3(spriteScale, spriteScale, 1.0f);
        return newObj;
    }
}

