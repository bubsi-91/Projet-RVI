using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    public NavMeshAgent agent;
    public Vector3 myVector;
    public Transform point1;
    public Transform point2;
    public Transform point3;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(point1.position);
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position, point1.position) < 0.01f)
            agent.SetDestination(point2.position);
        agent.SetDestination(point2.position);
    }
}
