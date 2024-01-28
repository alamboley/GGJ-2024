
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartScreen : MonoBehaviour
{
    public TextMeshProUGUI title;
    public Button start;
    void Start()
    {
        title.DOFade(0.5f, 0.75f).SetLoops(-1, LoopType.Yoyo);

        start.onClick.AddListener(() => SceneManager.LoadScene(1));
    }

    private void OnDestroy()
    {
        title.DOKill();
    }
}
