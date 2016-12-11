using UnityEngine;
using System.Collections;

public class shield : MonoBehaviour {
	public GameObject dumbArrow;
	public static int score=0 ;
	public float arrowRate = 0.65f;
	private float minX=13.1f,maxX=16.9f;
	private GameObject dummyDumb;
	private AudioSource audioSource;
	private float posX, posZ,posdX,posdY,posdZ,radius=2f,h=15f,variableLength=0.25f;

	// Use this for initialization
	void Start () {
		
		audioSource= GetComponent<AudioSource>();
		score = 0;
		InvokeRepeating ("dummyArrow", 0.4f,arrowRate);
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Player.gameFlag == 1)
			CancelInvoke ();

		if (Input.GetKeyDown (KeyCode.B) ){
																		                              	//square(x-h)+square(z)=square(radius)  
			posX = transform.position.x -variableLength;													//eqn of semicircle
			posX = Mathf.Clamp (posX, minX, maxX);
			posZ = Mathf.Sqrt (Mathf.Abs((radius*radius) - (posX * posX)-(h*h)+(2*h*posX)));
			transform.position = new Vector3 (posX, transform.position.y, posZ);
		}
		else if (Input.GetKeyDown (KeyCode.N) ){
			posX = transform.position.x + variableLength;
			posX = Mathf.Clamp (posX,minX, maxX);
			posZ = Mathf.Sqrt (Mathf.Abs((radius*radius) - (posX * posX)-(h*h)+(2*h*posX)));
			transform.position = new Vector3 (posX, transform.position.y, posZ);
		}
	}
		
	void OnTriggerEnter(Collider colld){
		
		if(colld.GetComponent<Arroww>()||colld.GetComponent<dumbArrow>()){
			audioSource.Play ();
			   score++;
	        	Destroy (colld.gameObject);
		 }
    }

	void dummyArrow(){
		
		posdX = Random.Range (2f, 29f);
		posdZ = Random.Range (15f, 24f);
		posdY = Random.Range(1.5f,4f);
		Vector3 posn = new Vector3 (posdX, posdY, posdZ);
		dummyDumb = Instantiate (dumbArrow, posn, Quaternion.Euler(0f,90f,0f)) as GameObject;
	}
		
}

