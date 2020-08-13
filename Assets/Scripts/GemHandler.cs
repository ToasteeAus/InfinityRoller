using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemHandler : MonoBehaviour
{

    public float amplitude = 1f;
    public float speed = 5f;
    private Rigidbody rb;
    private Vector3 initialPos;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        initialPos = rb.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
        float newY = Mathf.Sin(Time.time * speed) * amplitude;
        Vector3 position = new Vector3(0, newY, 1) - initialPos;
        rb.MovePosition(position);
    }
}
