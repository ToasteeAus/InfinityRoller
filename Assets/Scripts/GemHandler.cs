using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
        transform.Translate(Vector3.up * 1, Space.World);
        transform.Translate(Vector3.down * 1, Space.World);
    }
}
