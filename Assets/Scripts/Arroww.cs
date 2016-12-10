using UnityEngine;
using System.Collections;

public class Arroww : MonoBehaviour {
	float tanVal,posx,posz;
	public float speed=0.05f;
	int flag=0;
	int updateflag;
	public Transform target;
	float checkflag;
	private LevelManager levelManager;

	// Use this for initialization
	void Start () {
		levelManager = GameObject.FindObjectOfType<LevelManager> ();

		updateflag = 0;
		Debug.Log ("started here");
		checkflag = transform.position.x - target.transform.position.x;
		getRotation ();
	}
	
	// Update is called once per frame
	void Update () {
		if (updateflag == 1) {
			if (flag == 0) {
				//getRotation ();
				getPosition ();
			}
			if (posz - target.transform.position.z < 2) {
				flag = 1;	
			}
		}
	}

	void getRotation(){
		
		if (checkflag<0.0f) {
			tanVal = -(transform.position.z - target.transform.position.z) / (transform.position.x - target.transform.position.x);
			float y = Mathf.Atan (tanVal) * 180 / Mathf.PI;
			y = 90 - y;

			transform.Rotate(Vector3.down,y);
		} else if (checkflag>0.0f) {
			tanVal = (transform.position.x - target.transform.position.x) / (transform.position.z - target.transform.position.z);

			float y = Mathf.Atan (tanVal) * 180 / Mathf.PI;


			transform.Rotate(Vector3.up,y);

		} else
			tanVal = 0;
	
		Debug.Log ("ended here");
		updateflag = 1;

}
	void getPosition ()
	{
		if (checkflag > 0.0f) {
			posx = transform.position.x - speed;
			posz = transform.position.z - speed / tanVal;
		}
		else if (checkflag < 0.0f) {
			posx = transform.position.x + speed;
			posz = transform.position.z - speed * tanVal;
		}
		transform.position = new Vector3 (posx, transform.position.y, posz);
	}
	void OnTriggerEnter (Collider colld)
	{
		if (colld.GetComponent<Player> ()) {
			Debug.Log ("in arrow entered player");



		}

	}
}
