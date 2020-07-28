using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour {
	
	public float threshold;
	public Transform SpawnPoint;

	void FixedUpdate () {
		if (transform.position.y < threshold)
			transform.position = SpawnPoint.position;
	}
}