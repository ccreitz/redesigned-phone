using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialScreen : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.anyKeyDown) {
			GameObject.Find ("MenuManager").GetComponent<MenuManager> ().start_Tutorial ();
		}
	}
}
