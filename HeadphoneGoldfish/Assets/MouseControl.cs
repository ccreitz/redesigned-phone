using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseControl : MonoBehaviour
{
    public float sensitivity;
	private Rigidbody2D rigid_body;

    // Use this for initialization
    void Start()
    {
		rigid_body = transform.GetComponent<Rigidbody2D> ();
    }

    // Update is called once per frame
    void Update()
    {
		Vector3 curr_pos_in_viewport = Camera.main.WorldToViewportPoint (transform.position);
		bool is_player_on_screen = 0 < curr_pos_in_viewport.x && curr_pos_in_viewport.x < 1 &&
		                           0 < curr_pos_in_viewport.y && curr_pos_in_viewport.y < 1;

		if (Input.GetMouseButtonDown (0) && is_player_on_screen) {
			rigid_body.AddForce (Vector2.up*sensitivity, ForceMode2D.Impulse);
		}
    }
}
