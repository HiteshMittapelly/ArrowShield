using UnityEngine;
using System.Collections;

public class Arroww : MonoBehaviour {
	float tanVal,posx,posz;
    
	int flag=0;
	int updateflag;
	public Transform target;
	float differenceX,differenceZ;
	//private LevelManager levelManager;
	private Vector3 targetDir;
	public float Speed = 5f ;
	// Use this for initialization
	void Start () {
		//levelManager = GameObject.FindObjectOfType<LevelManager> ();

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
		/*
		if (checkflag > 0.0f) {
			posx = transform.position.x - speed;
			posz = transform.position.z - speed / tanVal;
		}
		else if (checkflag < 0.0f) {
			posx = transform.position.x + speed;
			posz = transform.position.z - speed * tanVal;
		}
		transform.position = new Vector3 (posx, transform.position.y, posz);
		*/
     }


	void OnTriggerEnter (Collider colld)
	{
		if (colld.GetComponent<Player> ()) {
			Debug.Log ("in arrow entered player");



		}

	}
}
