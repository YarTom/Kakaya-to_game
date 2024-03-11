using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public List<Transform> patrolPoint;
    public PlayerController player;
    public float viewAngle;

    private NavMeshAgent _navMeshAgent;
    private bool _isPlayerNotuced;
    // Start is called before the first frame update
    void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        NewPoint();
    }

    // Update is called once per frame
    void Update()
    {
        if (_navMeshAgent.remainingDistance == 0)
        {
            NewPoint();
        }

        var direction = player.transform.position - transform.position;

        PatrolUpdate();
        Chase();

        RaycastHit hit;
        if (Vector3.Angle(transform.forward, direction) < viewAngle)
        {
            if (Physics.Raycast(transform.position + Vector3.up, direction, out hit))
            {
                if (hit.collider.gameObject == player.gameObject)
                {
                    _isPlayerNotuced = true;
                }
                else
                {
                    _isPlayerNotuced = false;
                }
            }
            else
            {
                _isPlayerNotuced = false;
            }
        }
        else
        {
            _isPlayerNotuced = false;
        }
    }

    private void NewPoint()
    {
        _navMeshAgent.destination = patrolPoint[Random.RandomRange(0, patrolPoint.Count)].position;
    }
    private void PatrolUpdate()
    {

        if (!_isPlayerNotuced)
        {
            if(_navMeshAgent.remainingDistance == 0)
            {
                NewPoint();
            }
        }

    }

    private void Chase()
    {
        if (_isPlayerNotuced)
        {
            _navMeshAgent.destination = player.transform.position;
        }
        
    }
}
