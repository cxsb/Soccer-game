using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scoreb : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerEnter(Collider collider)
    {
        if (collider.name == "Soccer Ball Mesh")
        {
        	Vector3 pos;
            pos.x = 0;
            pos.y = 5;
            pos.z = 0;
            GameObject.Find("Soccer Ball Mesh").transform.position = pos;
            GameObject.Find("Soccer Ball Mesh").GetComponent<Rigidbody>().velocity=Vector3.zero;
            GameObject.Find("Soccer Ball Mesh").GetComponent<Rigidbody>().angularVelocity=Vector3.zero;
        }
    }
}
