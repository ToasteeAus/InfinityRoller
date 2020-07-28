using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


[RequireComponent(typeof(Rigidbody))]
public class PlayerControlScript : MonoBehaviour {


	public float speed;
	public Text countText;
	public Text winText;
	public Vector3 jump;
	public float jumpforce = 1.2f;
	public bool isGrounded;
	public float threshold;
	public Transform SpawnPoint;
	Camera m_MainCamera;

	private Rigidbody rb;
	private int count;

	void Start () {
		rb = GetComponent<Rigidbody> (); // Gets Rigidbody
		jump = new Vector3 (0.0f, 2.0f, 0.0f); // Sets up a basic jump Vector3 for position 
		count = 0; // Gemcounter
		SetCountText (); // Count Text
		winText.text = ""; // Win Text
	}

	void FixedUpdate () {
		float moveHorizontal = Input.GetAxis ("Horizontal"); // Getting Axes
		float moveVertical = Input.GetAxis ("Vertical"); // Getting Axes

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical ); // Setting up camera movement
		Vector3 relativeMovement = Camera.main.transform.TransformVector(movement); // Helping the camera move relative to player

		rb.AddForce (relativeMovement * speed); // Playermovement

		if (transform.position.y < threshold) { // When the player falls off the edge, once it reaches the threshold they are respawned with 0 velocity and 0 speed
			transform.position = SpawnPoint.position;
			GetComponent<Rigidbody> ().velocity = Vector3.zero;
			GetComponent<Rigidbody> ().angularVelocity = Vector3.zero;
		}


	}

	void OnCollisionStay() // Called whenever the ball hits a surface
	{
		isGrounded = true;
	}

	void Update(){ // Basic Update, checking each frame if Space is pressed to then Jump
		if (Input.GetKeyDown (KeyCode.Space) && isGrounded == true) {
			rb.AddForce (jump * jumpforce, ForceMode.Impulse);
			isGrounded = false;
		}
	}

	void OnTriggerEnter(Collider other) // Collecting Gems
	{
		if (other.gameObject.CompareTag ("Pick Up")) 
		{
			other.gameObject.SetActive (false);
			count = count + 1;
			SetCountText ();
		}
	}

	void SetCountText () // Checking Win condition
	{
		countText.text = "Count: " + count.ToString ();
		if (count >= 9) 
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
		}
	}
} 