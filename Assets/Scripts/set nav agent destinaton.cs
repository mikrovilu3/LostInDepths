using UnityEngine;
using UnityEngine.AI;

public class MoveToClickPoint : MonoBehaviour
{
    NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    Ray ray;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log(ray);
            RaycastHit hit;
             ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
            {
                agent.destination = hit.point;
            }
        }
    }
    private void OnDrawGizmos()
    {
            Gizmos.DrawRay(ray);
        
    }
}