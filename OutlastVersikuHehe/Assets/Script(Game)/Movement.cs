using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
    public float speed;
    GameController gc;
	// Use this for initialization
	void Start () {
        gc = GameObject.Find("GameController").GetComponent<GameController>();
    }
	
	// Update is called once per frame
	void Update () {
        Move();
    }

    void Move()
    {
        if (!gc.isOver)
        {
            if (Input.acceleration.x <= -0.2f)
            {
                transform.position = transform.position + Camera.main.transform.forward * -speed * Time.deltaTime;
            }

            if (Input.acceleration.x >= 0.2f)
            {
                transform.position = transform.position + Camera.main.transform.forward * speed * Time.deltaTime;
            }
        }
        
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Monster")
        {
            gc.isOver = true;
        }
    }
}
