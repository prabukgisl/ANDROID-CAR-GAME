using UnityEngine;
using System.Collections;

public class carController : MonoBehaviour {
	public float carSpeed;
	public float maxpos=2.2f;

	Vector3 position;
	public uiManager ui;
	public AudioManager am;

	bool currntPlatformAndroid=false;
	
	Rigidbody2D rb;
	void Awake(){
		rb = GetComponent<Rigidbody2D> ();
	
		#if UNITY_ANDROID
		currntPlatformAndroid=true;
	
		#else
		currntPlatformAndroid = false;
		#endif
		am.carSound.Play ();
	}

	// Use this for initialization
	void Start () {

		position = transform.position;
		if (currntPlatformAndroid == true) {
			Debug.Log ("Android");

		} else {
			Debug.Log ("Windows");
		}
	}
	
	// Update is called once per frame
	void Update(){ 
		if (currntPlatformAndroid == true) {
			//android code
			AcclerometerMove();

		} else {



			position .x += Input.GetAxis ("Horizontal") * carSpeed * Time.deltaTime;

			position.x = Mathf.Clamp (position.x, -2.2f, 2.2f);

			transform.position = position;
		}


		position = transform.position;
		position.x = Mathf.Clamp (position.x, -2.2f, 2.2f);
		
		transform.position = position;
	}
	void OnCollisionEnter2D(Collision2D col){
		if(col.gameObject.tag =="Enemy"){

			//Destroy (gameObject);
			gameObject.SetActive(false);
			ui.gameOverActivated();
			am.carSound.Stop();
		}
	}

	void AcclerometerMove(){

		float x = Input.acceleration.x;
		if (x < -0.1f) {
			MoveLeft ();
		} else if (x > 0.1f) {
			MoveRight ();
		} else {
			setVelacityZero ();
		}

	}
	public void MoveLeft(){
		rb.velocity = new Vector2 (-carSpeed, 0);
	}
	public void MoveRight(){
		rb.velocity = new Vector2 (carSpeed, 0);
	}
	public void setVelacityZero(){
		rb.velocity = Vector2.zero;

	}



}

