using System;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    public float stoppingDistance = 20f;
    private NavMeshAgent agent;
    private Transform target;

    private void Start()
    {
       
        agent = GetComponent<NavMeshAgent>();
        target = GameObject.FindWithTag("Player").transform;
        agent.autoTraverseOffMeshLink = true;
      
    }
    

    private void Update()
    {
        agent.SetDestination(target.position);
        float distance = Vector3.Distance(transform.position, target.position);
        var dir = (target.position - transform.position).normalized;
        var ray = new Ray(transform.position, dir);
        if (!Physics.Raycast(ray, out var hit)) return;
        
        if (hit.collider.CompareTag("Player"))
        {
            agent.destination = target.position;
        }
        

        if (distance > stoppingDistance)
        {
            agent.SetDestination(target.position);
        }
        else
        {
            Vector3 newPos = (transform.position - target.position).normalized * stoppingDistance;
            agent.SetDestination(target.position + newPos);
        }
    }
}
