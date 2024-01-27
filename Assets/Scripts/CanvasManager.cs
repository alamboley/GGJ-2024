using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    public PlayerController playerController;

    public TextMeshProUGUI bones;
    public int numBonesRequiredForBigEyes = 1;
    public TextMeshProUGUI pola;
    public Button bigEyes;

    int _bones = 0;
    int _pola = 0;
    void Start()
    {
        bigEyes.onClick.AddListener(_ActivateBigEyes);
    }

    public void FoundBone()
    {
        ++_bones;

        bones.text = "x " + _bones;

        _CanUseBigEyes();
    }

    void _CanUseBigEyes()
    {
        bigEyes.interactable = _bones >= numBonesRequiredForBigEyes;
    }

    void _ActivateBigEyes()
    {
        playerController.UseBigEyes();

        int numBones = _bones;

        _bones -= numBonesRequiredForBigEyes;
        if (_bones < 0)
            _bones = 0;

        DOVirtual.Int(numBones, _bones, 0.5f, (int value) => bones.text = "x " + value);
        _CanUseBigEyes();
    }

    public void FoundPola()
    {
        ++_pola;

        pola.text = "x " + _pola;
    }
}
