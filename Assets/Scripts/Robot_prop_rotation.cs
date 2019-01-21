using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot_prop_rotation : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(Vector3.up, 2000f * Time.deltaTime);
	}
}
