using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionMonster : MonoBehaviour {
    public bool isGazed;

    float time = 0;
    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {

        if (isGazed)
        {
            time += Time.deltaTime;

            if (time > 3)
            {
                Destroy(this.gameObject);
            }
        }

        else
        {
            time = 0;
        }
    }

    public void Gazed() {
        isGazed = true;
    }

    public void UnGazed()
    {
        isGazed = false;
    }
}
