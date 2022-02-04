using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    public NavMeshAgent agent;
    public Vector3 myVector;
    public List<Transform> points;
    public float d;
    private Vector3 nextPosition;
    public int nextIdPosition;

    // Start is called before the first frame update
    void Start()
    {
        nextIdPosition = 0;
        agent = GetComponent<NavMeshAgent>();
        nextPosition = points[nextIdPosition].position;
        agent.SetDestination(nextPosition);
        
        
    }

    // Update is called once per frame
    void Update()
    {  
        d = Vector3.Distance(transform.position, nextPosition);
        if (d < 2.5f) {
            if (nextIdPosition < points.Count - 1)
            {
                nextIdPosition++;
            }
            else 
            {
                nextIdPosition = 0;
            }
            nextPosition = points[nextIdPosition].position;
            agent.SetDestination(nextPosition);
        }
            
    }
}
