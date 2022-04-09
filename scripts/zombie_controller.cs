using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class zombie_controller : MonoBehaviour
{
    public NavMeshAgent zombie_agent;
    public GameObject hat;

    public Transform[] waypoints;
    private int waypoint_index;

    private float dist;


    void Start()
    {
        
        waypoint_index =0;
        zombie_agent.SetDestination(waypoints[0].position);
 //       Debug.Log(waypoint_index);

    }

    // Update is called once per frame
    void Update()
    {
        dist = Vector3.Distance(this.gameObject.transform.position,waypoints[waypoint_index].position);

        if(dist<=0.5f){
            increase_waypoint_index();
        }
        
    }

    void increase_waypoint_index()
    {
 //       Debug.Log(waypoint_index);
        if(waypoint_index >= (waypoints.Length-1) )
        {
            waypoint_index = 0;
        }
        else {
            waypoint_index++;
        }

        zombie_agent.SetDestination(waypoints[waypoint_index].position);
 //       Debug.Log(waypoint_index);
    }
}
