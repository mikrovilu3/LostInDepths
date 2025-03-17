using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class MoveToClickPoint : MonoBehaviour
{
    NavMeshAgent agent;
    public Camera Camera_debug;
    public GameObject target;
    public float searchRadius = 1;
    public float searchTime = 1;
    Vector3 randomOfSet ;
    void ReRandom()
    {
        randomOfSet = Random.insideUnitSphere * searchRadius ;
    }

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        InvokeRepeating("ReRandom", 0, searchTime);
    }
    Ray ray;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
             ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(Camera_debug.ScreenPointToRay(Input.mousePosition), out hit, 100))
            {
                target.transform.position = hit.point;
            }
            Debug.Log(hit.point);
        }
        agent.destination = target.transform.position + randomOfSet; 
    }
    private void OnDrawGizmos()
    {
            Gizmos.DrawRay(ray);
        
    }
}