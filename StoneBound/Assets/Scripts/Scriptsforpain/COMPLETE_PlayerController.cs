using UnityEngine;
using UnityEngine.AI;

public class COMPLETER_PlayerController : MonoBehaviour
{
    [SerializeField]private Camera cam;
    [SerializeField]private NavMeshAgent agent;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                agent.SetDestination(hit.point);
            }
        }
    }
}