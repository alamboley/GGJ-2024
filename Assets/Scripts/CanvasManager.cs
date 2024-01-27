using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    public PlayerController playerController;
    public GrandmaController grandmaController;

    public TextMeshProUGUI bones;
    public int numBonesRequiredForBigEyes = 1;
    public TextMeshProUGUI dogStatut;
    public int numBonesRequiredForNiceDog = 2;
    public BoxCollider dogBoxCollider;
    public TextMeshProUGUI pola;
    public Button bigEyes;
    public Button ForceFollowPlayer;

    int _bones = 0;
    int _pola = 0;
    void Start()
    {
        bigEyes.onClick.AddListener(_ActivateBigEyes);
        ForceFollowPlayer.onClick.AddListener(grandmaController.SetFollowPlayer);
    }

    public void FoundBone()
    {
        ++_bones;

        bones.text = "x " + _bones;

        _CanUseBigEyes();
        _CheckDogIsNice();
    }

    void _CanUseBigEyes()
    {
        bigEyes.interactable = _bones >= numBonesRequiredForBigEyes;
    }

    void _CheckDogIsNice()
    {
        if (_bones >= numBonesRequiredForNiceDog)
        {
            dogStatut.text = "Dog is happy";
            dogBoxCollider.enabled = false;
        }
        else
        {
            dogStatut.text = "Dog is not happy";
            dogBoxCollider.enabled = true;
        }
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
        _CheckDogIsNice();
    }

    public void FoundPola()
    {
        ++_pola;

        pola.text = "x " + _pola;
    }
}
