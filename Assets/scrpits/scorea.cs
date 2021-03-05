using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scorea : MonoBehaviour {

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
            collider.transform.position = pos;
            collider.GetComponent<Rigidbody>().velocity=Vector3.zero;
            collider.GetComponent<Rigidbody>().angularVelocity=Vector3.zero;
        }
    }
}
