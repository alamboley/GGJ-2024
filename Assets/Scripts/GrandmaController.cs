using DG.Tweening;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class GrandmaController : MonoBehaviour
{
    public PlayerController player;
    public Transform[] goals;
    public float delayUpdatePlayerPosition;
    public int maxLastTimeSeen;

    public Transform home;
    public Transform car;

    private NavMeshAgent _agent;
    private bool _isFollowingPlayer = false;
    private float _lastTimeSeenPlayer = 0;

    private bool _mustGoHome = false;

    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();

    }

    private void Update()
    {
        if (_agent.remainingDistance < 0.05)
        {
            _GetRandomGoal();
            _mustGoHome = false;
        }

        if (!_agent.isStopped || !_mustGoHome)
        {
            _DoRaycast(transform.position);
            _DoRaycast(transform.position + Vector3.left);
            _DoRaycast(transform.position + Vector3.right);
        }
    }

    private void _DoRaycast(Vector3 origin)
    {
        if (Physics.Raycast(origin, transform.TransformDirection(Vector3.forward), out RaycastHit hit, 10))
        {
            Debug.DrawRay(origin, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);

            if (hit.collider.name == "Player")
            {
                FollowPlayer();
            }
        }
    }

    private void _GetRandomGoal()
    {
        System.Random random = new System.Random();
        int randomNumber = random.Next(goals.Length);

        _agent.destination = goals[randomNumber].position;
    }

    public void GetShockedByCatBigEyes(int delay)
    {
        _agent.isStopped = true;
        _mustGoHome = true;
        _isFollowingPlayer = false;
        GoHome();

        DOVirtual.DelayedCall(delay, () => _agent.isStopped = false);
    }

    public void GoHome()
    {
        _agent.destination = home.position;
    }
    public void GoToCar()
    {
        _agent.destination = car.position;
    }

    public void FollowPlayer()
    {
        Debug.Log("Follow player");
        _lastTimeSeenPlayer = Time.time;

        if (!_isFollowingPlayer)
        {
            _isFollowingPlayer = true;
            StartCoroutine(_FollowPlayer());
        }
    }

    IEnumerator _FollowPlayer()
    {
        while (_isFollowingPlayer)
        {
            if (Time.time - _lastTimeSeenPlayer > maxLastTimeSeen)
            {
                Debug.Log("didn't see player since a long time, unfollow");
                _UnfollowPlayer();
            }
            else
            {
                Debug.Log("update follow player position");
                _agent.destination = player.transform.position;
            }

            yield return new WaitForSeconds(delayUpdatePlayerPosition);
        }
    }

    public void SetFollowPlayer()
    {
        _agent.destination = player.transform.position;
    }

    private void _UnfollowPlayer()
    {
        Debug.Log("Unfollow player");
        _isFollowingPlayer = false;
        _GetRandomGoal();
    }

    public void StartSlowZone()
    {
        _agent.speed *= 0.5f;
    }

    public void EndSlowZone()
    {
        _agent.speed *= 2f;
    }

    public void LineObstacle(int waitTime)
    {
        float speed = _agent.speed;
        _agent.speed = 0;
        DOVirtual.DelayedCall(waitTime, () => _agent.speed = speed);
    }
}