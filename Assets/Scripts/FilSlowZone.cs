using UnityEngine;

public class FilSlowZone : MonoBehaviour
{
    public GrandmaController grandmaController;
    public GameObject filDetendu;
    public GameObject filTendu;

    public int lengthWait;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other);
        if (other.name == "GrandmaCollider" && filTendu.activeInHierarchy)
        {
            Debug.Log("grandma line...");
            grandmaController.LineObstacle(lengthWait);
        }
    }
}
