using UnityEngine;
using System.Collections;

public class shield : MonoBehaviour {
	public float minX=13.1f,maxX=16.9f;
	private float posX, posZ;
	public static int score=0 ;
	// Use this for initialization
	void Start () {
		score = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.B) ){
			Debug.Log ("pressed b");
			posX = transform.position.x - 0.25f;
			posX = Mathf.Clamp (posX, minX, maxX);
			posZ = Mathf.Sqrt (Mathf.Abs(4 - (posX * posX)-225+(30*posX)));

			transform.position = new Vector3 (posX, transform.position.y, posZ);

		}
		else if (Input.GetKeyDown (KeyCode.N) )
		{
			Debug.Log ("pressed n");
			posX = transform.position.x + 0.25f;
			posX = Mathf.Clamp (posX,minX, maxX);
			posZ = Mathf.Sqrt (Mathf.Abs(4 - (posX * posX)-225+(30*posX)));

			transform.position = new Vector3 (posX, transform.position.y, posZ);

		}
	}
		void OnTriggerEnter(Collider colld){
		if(colld.GetComponent<Arroww>()){
			 Debug.Log("arrow entered shield");
			   score++;
	        	Destroy (colld.gameObject);
		}
	}
	}

