using UnityEngine;

public class TuyauController : MonoBehaviour
{
    public GameObject TuyauOK;
    public GameObject TuyauNotOK;
    public BoxCollider TuyauSlowZone;
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        TuyauNotOK.SetActive(true);
        TuyauSlowZone.gameObject.SetActive(true);
        TuyauOK.SetActive(false);
    }
}
