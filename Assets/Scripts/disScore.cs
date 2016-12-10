using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class disScore : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		Text text = GetComponent<Text> ();
		text.text = "your score is" + shield.score.ToString ();

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
