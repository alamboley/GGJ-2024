using DG.Tweening;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CanvasManager canvasManager;
    public GrandmaController grandmaController;

    public float speed = 10f;
    public float rotationSpeed = 5f;

    public int bigEyesTimeLength = 3;
    
    private Vector3 _moveDirection;

    private bool _canMove = true;

    void Start()
    {
        
    }

    void Update()
    {
        if (!_canMove)
            return;

        _moveDirection = Vector3.zero;
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.Z) || Input.GetKey(KeyCode.W))
        {
            _moveDirection += transform.forward;
        }
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            _moveDirection -= transform.forward;
        }
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.A))
        {
            transform.Rotate(new Vector3(0, 1, 0), -rotationSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            transform.Rotate(new Vector3(0, 1, 0), rotationSpeed * Time.deltaTime);
        }

        transform.position += _moveDirection * Time.deltaTime * speed;
    }

    public void UseBigEyes()
    {
        _canMove = false;

        grandmaController.GetShockedByCatBigEyes(bigEyesTimeLength);

        DOVirtual.DelayedCall(bigEyesTimeLength, () => _canMove = true);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);

        if (other.name == "WinZone")
        {
            Debug.Log("WIIIIN");
            return;
        }
        if (other.name == "Car")
            grandmaController.GoToCar();
        else if (other.GetComponent<GrandmaController>())
            Debug.Log("Game over");
        else if (other.GetComponent<BoneComponent>())
        {
            other.GetComponent<BoneComponent>().OnCollect();
            canvasManager.FoundBone();
        }
        else if (other.GetComponent<PolaComponent>())
        {
            other.GetComponent<PolaComponent>().OnCollect();
            canvasManager.FoundPola();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision);
    }
}
