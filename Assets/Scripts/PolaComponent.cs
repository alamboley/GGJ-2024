using DG.Tweening;
using UnityEngine;

public class PolaComponent : MonoBehaviour
{
    void Start()
    {
        float _speed = Random.Range(0.5f, 1f);

        transform.DORotate(Vector3.up * 180, _speed).SetLoops(-1, LoopType.Yoyo);
        transform.DOMoveY(1f, _speed).SetLoops(-1, LoopType.Yoyo);
    }

    public void OnCollect()
    {
        transform.DOKill();
        Destroy(gameObject);
    }
}
