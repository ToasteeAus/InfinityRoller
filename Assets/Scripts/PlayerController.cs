using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{


    public float speed;
    public Vector3 jump;
    public float jumpforce = 1.2f;
    public bool isGrounded;
    public float threshold; // death y axis level
    //public Transform SpawnPoint;
    Camera m_MainCamera;

    private Rigidbody rb;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        rb = GetComponent<Rigidbody>(); // Gets Rigidbody
        jump = new Vector3(0.0f, 2.0f, 0.0f); // Sets up a basic jump Vector3 for position 
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal"); // Getting Axes
        float moveVertical = Input.GetAxis("Vertical"); // Getting Axes

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical); // Setting up camera movement
        Vector3 relativeMovement = Camera.main.transform.TransformVector(movement); // Helping the camera move relative to player

        rb.AddForce(relativeMovement * speed); // Playermovement

        //if (transform.position.y < threshold)
        //{ // When the player falls off the edge, once it reaches the threshold they are respawned with 0 velocity and 0 speed
          //  transform.position = SpawnPoint.position;
            //GetComponent<Rigidbody>().velocity = Vector3.zero;
            //GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        //}
    }

    void OnCollisionStay() // Called whenever the ball hits a surface
    {
        isGrounded = true;
    }

    void Update()
    { // Basic Update, checking each frame if Space is pressed to then Jump
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            rb.AddForce(jump * jumpforce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

}