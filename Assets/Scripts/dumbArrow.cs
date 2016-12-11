using UnityEngine;
using System.Collections;

public class dumbArrow : MonoBehaviour {
	public float Speed = 10f ;

	private AudioSource audioSource;
	private int updateflag;
	private Vector3 dummyTarget,targetDir;
	private float differenceX,differenceZ,tanVal,posx,posz;


	// Use this for initialization
	void Start () {
		
		audioSource= GetComponent<AudioSource>();
		float dummyX,dummyY,dummyZ;
		dummyX = Random.Range (11f, 19f);
		dummyY = Random.Range (1f, 3f);
		dummyZ = -3f;

		dummyTarget = new Vector3 (dummyX, dummyY, dummyZ);
		targetDir = transform.position - dummyTarget;
		differenceX = targetDir.x;
		differenceZ = targetDir.z;
		getRotation ();
	}
	
	// Update is called once per frame
	void Update () {
		
		getPosition ();
	}

	void getRotation(){
		
		if (differenceX < 0.0f) {
			tanVal = -differenceZ / differenceX;
			float y = Mathf.Atan (tanVal) * 180 / Mathf.PI;
			y = 90 - y;
			transform.Rotate (Vector3.down, y);
		} else if (differenceX > 0.0f) {
			tanVal = differenceX / differenceZ;
			float y = Mathf.Atan (tanVal) * 180 / Mathf.PI;
			transform.Rotate (Vector3.up, y);
		}else
			tanVal = 0;
	}


	void getPosition ()
	{
		float smoothSpeed = Speed * Time.deltaTime;
		transform.position = Vector3.MoveTowards (transform.position, dummyTarget,smoothSpeed);
	}


	void OnTriggerEnter (Collider colld)
	{
		if (colld.GetComponent<soundColliderScipt> ()) {
			audioSource.PlayDelayed (0.1f);
		}

	}
}
