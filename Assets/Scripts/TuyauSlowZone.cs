using UnityEngine;

public class TuyauSlowZone : MonoBehaviour
{
    public GrandmaController grandmaController;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other);
        if (other.name == "GrandmaCollider")
        {
            grandmaController.StartSlowZone();
            Debug.Log("tuyau slow zone start");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "GrandmaCollider")
        {
            grandmaController.EndSlowZone();
            Debug.Log("tuyau slow zone end");
        }
    }
}
