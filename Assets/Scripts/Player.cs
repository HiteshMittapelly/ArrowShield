using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	
	public GameObject Arrow;

	public static int gameFlag=0;
	private LevelManager levelManager;

	private GameObject ArrowPos;
	private Random rnd = new Random (); 

	private int numArrow;
	private float posX, posY, posZ;

	// Use this for initialization
	void Start () {
		gameFlag = 0;
		numArrow = 0;
		levelManager = GameObject.FindObjectOfType<LevelManager> ();

		InvokeRepeating ("CreateArrow", 3f, 6f);

	}
	
	// Update is called once per frame
	void Update () {
		if (numArrow > 5) {
			numArrow = 0;
			CancelInvoke ();
			levelManager.LoadLevel ("Won");
		}
		
	}



	
	void CreateArrow(){
		
		posX = Random.Range (3f, 27f);
		posZ = Random.Range (18f, 22f);
		posY = 2f;
		Vector3 posn = new Vector3 (posX, posY, posZ);
		Vector3 rotn = new Vector3 (0f, 90f, 0f);

		ArrowPos = Instantiate (Arrow, posn ,Quaternion.Euler(0f,90f,0f)) as GameObject;
		numArrow++;
	}
	void OnTriggerEnter (Collider colld)
	{
		if (colld.GetComponent<Arroww> ()||colld.GetComponent<dumbArrow>()) {
			gameFlag = 1;
			//Destroy (colld.gameObject);
			//Destroy (gameObject);
			levelManager.LoadLevel("Lose");

		}

	}
}
 