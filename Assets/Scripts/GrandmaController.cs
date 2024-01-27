using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class GrandmaController : MonoBehaviour
{
    public PlayerController player;
    public Transform[] goals;
    public float delayUpdatePlayerPosition;

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

    public void FollowPlayer()
    {
        Debug.Log("Follow player");

        StartCoroutine(_FollowPlayer());
    }

    IEnumerator _FollowPlayer()
    {
        while (true)
        {
            Debug.Log("update player position");

            _agent.destination = player.transform.position;

            yield return new WaitForSeconds(delayUpdatePlayerPosition);
        }
    }

    public void UnfollowPlayer()
    {
        Debug.Log("Unfollow player");
        //_GetRandomGoal();
    }
}