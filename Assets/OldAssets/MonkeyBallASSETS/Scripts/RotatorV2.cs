using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatorV2 : MonoBehaviour {
	

	float speed = 5f;

	float height = 0.5f;

	void Update () {
		transform.Rotate (new Vector3 (45, 30, 15) * Time.deltaTime);
	}
}