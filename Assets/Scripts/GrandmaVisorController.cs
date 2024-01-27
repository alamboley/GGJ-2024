using UnityEngine;

public class GrandmaVisorController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerController>())
            GetComponentInParent<GrandmaController>().FollowPlayer();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<PlayerController>())
            GetComponentInParent<GrandmaController>().UnfollowPlayer();
    }
}
