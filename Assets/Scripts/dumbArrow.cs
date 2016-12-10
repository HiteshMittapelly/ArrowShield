using UnityEngine;
using System.Collections;

public class dumbArrow : MonoBehaviour {
	float tanVal,posx,posz;


	int updateflag;
	private Vector3 dummyTarget;
	float differenceX,differenceZ;
	//private Transform target;
	private Vector3 targetDir;
	public float Speed = 10f ;
	// Use this for initialization
	void Start () {
		float dummyX,dummyY,dummyZ;
		dummyX = Random.Range (11f, 19f);
		dummyY = Random.Range (1f, 3f);
		dummyZ = -3f;

		dummyTarget = new Vector3 (dummyX, dummyY, dummyZ);
		targetDir = transform.position -dummyTarget;
		differenceX = targetDir.x;
		differenceZ = targetDir.z;
		getRotation ();
	}
	
	// Update is called once per frame
	void Update () {
		getPosition ();
	}

	void getRotation(){

		if (differenceX<0.0f) {
			tanVal = -differenceZ / differenceX;
			float y = Mathf.Atan (tanVal) * 180 / Mathf.PI;
			y = 90 - y;

			transform.Rotate(Vector3.down,y);
		} else if (differenceX>0.0f) {
			tanVal = differenceX / differenceZ;

			float y = Mathf.Atan (tanVal) * 180 / Mathf.PI;


			transform.Rotate(Vector3.up,y);

		} else
			tanVal = 0;




	}


	void getPosition ()
	{
		float smoothSpeed = Speed * Time.deltaTime;
		transform.position = Vector3.MoveTowards (transform.position, dummyTarget,smoothSpeed);
	}
}
