using UnityEngine;
using System.Collections;

public class Back : MonoBehaviour {
	private LevelManager levelmanager;
	// Use this for initialization
	void Start () {
		levelmanager = GameObject.FindObjectOfType<LevelManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.B)) {
			levelmanager.LoadLevel ("Game");
		}
	}
}
