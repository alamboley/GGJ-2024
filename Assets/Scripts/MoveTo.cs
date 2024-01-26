using UnityEngine;
using UnityEngine.AI;

public class MoveTo : MonoBehaviour
{
    public Transform[] goals;

    private NavMeshAgent _agent;

    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();

    }

    private void Update()
    {
        if (_agent.remainingDistance < 0.1)
        {
            _GetRandomGoal();
        }
    }

    private void _GetRandomGoal()
    {

        System.Random random = new System.Random();
        int randomNumber = random.Next(goals.Length);

        _agent.destination = goals[randomNumber].position;
    }
}