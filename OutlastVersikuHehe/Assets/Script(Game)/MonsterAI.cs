using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterAI : MonoBehaviour {
    public GameObject target;
    public bool targetInRange, seeRange;
    public float searchRadius, mSpeed, wanderRadius;

    NavMeshAgent agent;
    float x, z, lastx = 0, lastz = 0, angle;
    int goWander = 0;
    // Use this for initialization
    void Start () {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = true;
        agent.speed = mSpeed;
        agent.updatePosition = true;
    }
	
	// Update is called once per frame
	void Update () {
        DrawCircle();
        ScanPlayer();
    }

    void DrawCircle()
    {
        for(int i=0; i < 360; i++)
        {
            angle = i * Mathf.PI / 180;
            x = (searchRadius * Mathf.Cos(angle)) + transform.position.x;
            z = (searchRadius * Mathf.Sin(angle)) + transform.position.z;

            if(i == 0)
            {
                if (seeRange)
                {
                    Debug.DrawLine(new Vector3(x, 0, z), new Vector3(x, 0, z));
                }
                lastx = x;
                lastz = z;
            }

            else
            {
                if (seeRange)
                {
                    Debug.DrawLine(new Vector3(lastx, 0, lastz), new Vector3(x, 0, z));
                }
                lastx = x;
                lastz = z;
            }
        }
    }

    void ScanPlayer()
    {
        float distance = Vector3.Distance(this.transform.position, target.transform.position);
        if (distance <= searchRadius)
        {
            agent.SetDestination(target.transform.position);
        }

        else
        {
            if(goWander == 0)
            {
                Vector3 newpos = RandomNavSphere(this.transform.position, wanderRadius, -1);
                agent.SetDestination(newpos);
                goWander = 1;
            }

            if(!agent.hasPath || agent.velocity.sqrMagnitude == 0)
            {
                goWander = 0;
            }
           
        }
    }

    public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask)
    {
        Vector3 randDirection = Random.insideUnitSphere * dist;

        randDirection += origin;

        NavMeshHit navHit;

        NavMesh.SamplePosition(randDirection, out navHit, dist, layermask);

        return navHit.position;
    }

}
