using DG.Tweening;
using UnityEngine;

public class OsComponent : MonoBehaviour
{
    void Start()
    {
        transform.DOMoveY(1f, 0.5f).SetLoops(-1, LoopType.Yoyo);
    }

    public void OnCollect()
    {
        transform.DOKill();
        Destroy(gameObject);
    }
}
