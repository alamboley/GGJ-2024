using UnityEngine;

public class TwoStateObjects : MonoBehaviour
{
    public Transform firstChild;
    public Transform secondChild;
    private void OnTriggerEnter(Collider other)
    {
        secondChild.gameObject.SetActive(true);
        firstChild.gameObject.SetActive(false);
    }
}
