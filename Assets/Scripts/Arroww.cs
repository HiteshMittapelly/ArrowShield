using UnityEngine;
using System.Collections;

public class Arroww : MonoBehaviour {
	public float Speed = 5f ;
	public Transform target;

	private AudioSource audioSource;
	private int flag=0,updateflag;
	private float differenceX,differenceZ,tanVal,posx,posz;
	private Vector3 targetDir;

	// Use this for initialization
	void Start () {
		
		audioSource= GetComponent<AudioSource>();
		updateflag = 0;
		Debug.Log ("started here");
		targetDir = transform.position - target.transform.position;
		differenceX = targetDir.x;
		differenceZ = targetDir.z;
		getRotation ();
	
	}
	
	// Update is called once per frame
	void Update () {
		
		if (updateflag == 1) {
			if (flag == 0) {
				getPosition ();
			}
		}
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
	   	updateflag = 1;

    }

	void getPosition ()
	{
		float smoothSpeed = Speed * Time.deltaTime;
		transform.position = Vector3.MoveTowards (transform.position, target.transform.position,smoothSpeed);
	}

	void OnTriggerEnter (Collider colld)
	{
		if (colld.GetComponent<soundColliderScipt> ()) {
			audioSource.PlayDelayed (0.1f);
		}
	}
}
