using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed = 10f;
    public float rotationSpeed = 5f;
    
    private Vector3 _moveDirection;

    void Start()
    {
        
    }

    void Update()
    {
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
}
