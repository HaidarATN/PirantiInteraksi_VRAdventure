using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
    public float speed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Move();
    }

    void Move()
    {
        if(Input.acceleration.x <= -0.5f)
        {
            transform.position = transform.position + Camera.main.transform.forward * -speed * Time.deltaTime;
        }

        if (Input.acceleration.x >= 0.5f)
        {
            transform.position = transform.position + Camera.main.transform.forward * speed * Time.deltaTime;
        }
    }
}
