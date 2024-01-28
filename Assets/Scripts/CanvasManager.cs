using DG.Tweening;
using DG.Tweening.Core.Easing;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : PersistentSingleton<CanvasManager>
{
    public PlayerController playerController;
    public GrandmaController grandmaController;

    public TextMeshProUGUI bones;
    public int numBonesRequiredForBigEyes = 1;
    public Image dogStatut;
    public Sprite dogOK;
    public Sprite dogNotOK;
    public int numBonesRequiredForNiceDog = 2;
    public BoxCollider dogBoxCollider;
    public TextMeshProUGUI pola;
    public Button ForceFollowPlayer;

    public HorizontalLayoutGroup polasLayoutGroup;

    public Image grandmaImg;
    public Sprite grandmaOK;
    public Sprite grandmaNotOK;
    public Sprite grandmaShocked;

    public Button catBtn;

    public GameObject win;
    public GameObject loose;

    int _bones = 0;
    int _pola = 0;
    void Start()
    {
        catBtn.onClick.AddListener(_ActivateBigEyes);
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
        catBtn.interactable = _bones >= numBonesRequiredForBigEyes;
    }

    void _CheckDogIsNice()
    {
        if (_bones >= numBonesRequiredForNiceDog)
        {
            dogStatut.sprite = dogOK;
            dogBoxCollider.enabled = false;
        }
        else
        {
            dogStatut.sprite = dogNotOK;
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
        polasLayoutGroup.transform.GetChild(_pola).gameObject.SetActive(true);

        ++_pola;

        pola.text = "x " + _pola;
    }

    // state 0 - ok
    // state 1 - notok
    // state 2 - shocked
    public void UpdateStatutsGrandma(int state)
    {
        if (state == 0)
            grandmaImg.sprite = grandmaOK;
        else if (state == 1)
            grandmaImg.sprite = grandmaNotOK;
        else if (state == 2)
            grandmaImg.sprite = grandmaShocked;
    }
}
