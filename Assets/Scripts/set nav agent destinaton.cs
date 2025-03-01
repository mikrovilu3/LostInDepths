using System;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class MoveToClickPoint : MonoBehaviour
{
    NavMeshAgent agent;
    public Camera Camera_debug;
    [Tooltip("0 = player; 1 = low health hiding spot; 2 =< patrol points")]
    public GameObject [] targets;
    public float searchRadius = 1;
    public float searchTime = 1;
    public float patrolChangeTime = 5;
    public float MaxHealth = 100;
    public float Health => MaxHealth;
    public float LowHealthThreshold = 20;
    Vector3 randomOfSet ;
    public int currentTarget = 1;
    void ReRandom()
    {
        randomOfSet = UnityEngine.Random.insideUnitSphere * searchRadius ;
        Invoke("ReRandom", searchTime);
    }

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        ReRandom();
    }
    
    void Update()
    {
        
        int nextUpdateSecond = 0;
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera_debug.ScreenPointToRay(Input.mousePosition), out hit, 100))
            {
                targets[0].transform.position = hit.point;
            }
            Debug.Log(hit.point);
        }
        if (targets[0] != null)
        {
           
            if (Health > LowHealthThreshold)
            {
                if (Physics.Raycast(transform.position, (transform.position - targets[0].transform.position).normalized, 1000, 8))
                {
                    Debug.Log("fuck");
                    agent.destination = targets[0].transform.position + randomOfSet;
                    currentTarget = 1;
                }
                else
                {
                    agent.destination = targets[currentTarget-1].transform.position + randomOfSet;
                    if (1 > Math.Floor(Time.time) % patrolChangeTime && currentTarget >= targets.Length && nextUpdateSecond==Math.Floor(Time.time) )
                    {   nextUpdateSecond = 1+Convert.ToInt32( Math.Floor(Time.time));
                        currentTarget = 1;
                    }
                    if (currentTarget < targets.Length && 1 > Math.Floor(Time.time) % patrolChangeTime && nextUpdateSecond==Math.Floor(Time.time) )
                    {
                        nextUpdateSecond = 1+Convert.ToInt32( Math.Floor(Time.time));
                        Debug.Log("updated" +Time.time+" "+ Math.Floor(Time.time)+" "+nextUpdateSecond+" "+ Convert.ToInt32(Math.Floor(Time.time)));
                        currentTarget++;
                    }
                }

            }
            else if (Health < LowHealthThreshold)
            {
                agent.destination = targets[1].transform.position + randomOfSet;
            }
        }
    }
    
}