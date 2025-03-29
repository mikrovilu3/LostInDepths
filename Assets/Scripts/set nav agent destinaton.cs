using System;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class MoveToClickPoint : MonoBehaviour
{
    NavMeshAgent agent;
    public Camera Camera_debug;
    [Tooltip("0 = player; 1 = low health hiding spot; 1 =< patrol points")]
    public GameObject [] targets;
    public float searchRadius = 1;
    public float searchTime = 1;
    public int patrolChangeTime = 5;
    public float MaxHealth = 100;
    public float Health ;
    public float LowHealthThreshold = 20;
    Vector3 randomOfSet ;
    public int currentTarget = 1;
    public GameObject health_bar;
       Slider health_slider;
    public float damage;
    void ReRandom()
    {
        randomOfSet = UnityEngine.Random.insideUnitSphere * searchRadius ;
        Invoke("ReRandom", searchTime);
    }
    Ray ray;
    void Start()
    {   health_slider = health_bar.GetComponent<Slider>();
        agent = GetComponent<NavMeshAgent>();
        ReRandom();
        Health = MaxHealth;
        currentTarget = 1;
    }
    double nextUpdateSecond = 0;RaycastHit hit;
    void Update()
    {
        
        
        if (Input.GetMouseButtonDown(0))
        {
             
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
                 ray = new Ray (transform.position,targets[0].transform.position-transform.position+new Vector3(0f,1f,0f)+(UnityEngine.Random.insideUnitSphere*0.2f));
                if (Physics.Raycast(ray, out hit, float.PositiveInfinity)&&(hit.collider != null && hit.collider.name == "player colider" || hit.collider.name == " XR Origin (XR Rig)"))
                {
                    if (3f > Vector3.Distance(targets[0].transform.position, transform.position)) {
                        targets[0].GetComponent<Dsamage_Handeler>().Take(damage);
                        Debug.Log("dealt damage");
                    }
                       // Debug.Log(Vector3.Distance(targets[0].transform.position, transform.position));

                        currentTarget = 0;
                        nextUpdateSecond = Math.Floor(Time.time) + 1;
                    
                }
                else
                {


                    if (nextUpdateSecond == Math.Floor(Time.time))
                    {

                        nextUpdateSecond = patrolChangeTime + Math.Floor(Time.time);
                        if (currentTarget == targets.Length - 1)
                        {
                            currentTarget = 1;
                           // Debug.Log(" reset " + Time.time + " " + Math.Floor(Time.time) + " " + nextUpdateSecond + " " + targets.Length);
                        }
                        else if (currentTarget < targets.Length)
                        {
                            currentTarget++;
                           // Debug.Log("iterate " + Time.time + " " + Math.Floor(Time.time) + " " + nextUpdateSecond + " " +currentTarget + " " + targets.Length + " " + Time.deltaTime);
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
        if (health_slider != null)
        {
            health_slider.value = Health;
        }
        else { Debug.LogError("health slider is null"); }
    }
    
}