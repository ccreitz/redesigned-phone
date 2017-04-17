using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishCharacter : MonoBehaviour {
	public GameObject fishDeath;
	public Animation deathAnim;
	public Animation headphoneAnim;
    public float invTime;
    public Color invColor;
    private float lastInv;
	private bool isDying;
    public float blinkSpeed;

    // Use this for initialization
    void Start () {
        lastInv = Time.time - invTime - 1;
		isDying = false;
		transform.position = Camera.main.ScreenToWorldPoint (new Vector3 (Screen.width*0.1f, Screen.height*0.5f, 10));
	}
	
	// Update is called once per frame
	void Update () {
        if (!isInv())
        {
            
             GameObject.Find("PowerupGlasses").GetComponent<SpriteRenderer>().enabled = false;
        }
        GetComponent<SpriteRenderer>().color = (isInv() && ((Time.time%blinkSpeed) < blinkSpeed/2)) ? invColor : Color.white;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Damaging"))
        {
            GameObject.FindGameObjectWithTag("GameController").GetComponent<FishGameController>().Damaged();
        }
        if(collision.gameObject.CompareTag("Powerup"))
        {
            lastInv = Time.time;
            GameObject.Find("PowerupGlasses").GetComponent<SpriteRenderer>().enabled = true;
            GameObject.FindGameObjectWithTag("MusicController").GetComponent<MusicController>().GotPowerup();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Scoring"))
        {
            GameObject.FindGameObjectWithTag("GameController").GetComponent<FishGameController>().AddScore();
        }
    }

    public bool isInv()
    {
        return Time.time - lastInv < invTime;
    }

	public void die() {
		isDying = true;
		SpriteRenderer renderer = (SpriteRenderer) this.gameObject.GetComponent (typeof(SpriteRenderer));
		renderer.enabled = false;
		BoxCollider2D collider = (BoxCollider2D) this.gameObject.GetComponent (typeof(BoxCollider2D));
		collider.enabled = false;

		fishDeath.transform.position = this.transform.position;
		fishDeath.SetActive (true);
		deathAnim.Play();
		headphoneAnim.Play();
	}

	public bool isDead() {
		if (deathAnim != null) {
			return !deathAnim.isPlaying && isDying;
		} else {
			return false;
		}
	}
}
