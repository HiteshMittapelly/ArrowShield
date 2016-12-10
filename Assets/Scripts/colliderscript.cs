using UnityEngine;
using System.Collections;

public class colliderscript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider co)
	{
		Destroy (co.gameObject);
	}
}
