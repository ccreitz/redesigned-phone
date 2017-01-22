using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCommon : MonoBehaviour
{
    public AudioClip[] collisionSounds;
    protected AudioSource source;

    virtual protected void Start()
    {
        source = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (source != null && collisionSounds.Length > 0)
            {
                source.clip = collisionSounds[(int)(Random.value*collisionSounds.Length)];
                source.Play();
            }
        }
    }
}
