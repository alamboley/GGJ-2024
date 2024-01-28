using UnityEngine;

public class TwoStateObjects : MonoBehaviour
{
    public Transform firstChild;
    public Transform secondChild;
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerController>())
        {
            secondChild.gameObject.SetActive(true);
            firstChild.gameObject.SetActive(false);
        }
    }
}
