using System;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class MoveToClickPoint : MonoBehaviour
{
    NavMeshAgent agent;
    public Camera Camera_debug;
    [Tooltip("0 = player; 1 = low health hiding spot; 1 =< patrol points")]
    public GameObject [] targets;
    public float searchRadius = 1;
    public float searchTime = 1;
    public float patrolChangeTime = 5;
    public float MaxHealth = 100;
    public float Health ;
    public float LowHealthThreshold = 20;
    Vector3 randomOfSet ;
    public int currentTarget = 1;
    void ReRandom()
    {
        randomOfSet = UnityEngine.Random.insideUnitSphere * searchRadius ;
        Invoke("ReRandom", searchTime);
    }
    Ray ray;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        ReRandom();
        Health = MaxHealth;
    }
    int nextUpdateSecond = 0;
    void Update()
    {
        
        
        if (Input.GetMouseButtonDown(0))
        {
             
            if (Physics.Raycast(Camera_debug.ScreenPointToRay(Input.mousePosition), out RaycastHit hit, 100))
            {
                targets[0].transform.position = hit.point;
            }
            Debug.Log(hit.point);
        }
        if (targets[0] != null)
        {
            
            if (Health > LowHealthThreshold)
            {
                 ray = new Ray (transform.position,targets[0].transform.position);Physics.Raycast(ray,out, 1000, 8)
                if ()
                {
                    Debug.Log("fuck");
                    currentTarget = 0;
                }
                else
                {
                    
                    if (nextUpdateSecond == Math.Floor(Time.time))
                    {
                       
                        nextUpdateSecond = Convert.ToInt32(patrolChangeTime + Math.Floor(Time.time));
                        if (currentTarget == targets.Length-1)
                        {
                            currentTarget = 1;
                            Debug.Log(" reset " + Time.time + " " + Math.Floor(Time.time) + " " + nextUpdateSecond+" "+targets.Length);
                        }
                        else if (currentTarget < targets.Length)
                        {
                            currentTarget++;
                            Debug.Log("iterate " + Time.time + " " + Math.Floor(Time.time) + " " + nextUpdateSecond);
                        }
                    }
                    
                }
                agent.destination = targets[currentTarget].transform.position + randomOfSet;
            }
            else if (Health < LowHealthThreshold)
            {
                agent.destination = targets[1].transform.position + randomOfSet;
            }
        }
    }
    public void Take(float damage)
    {
        Health -= damage;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(ray);
    }
}