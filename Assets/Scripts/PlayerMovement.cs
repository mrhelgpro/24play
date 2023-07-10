using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float Speed = 5;
    public Vector2 Clamp = new Vector2(-2, 2);

    private float _direction;
    private float _horizontal;
    private float _previousMousePosition;
    private bool _previousInputDown;
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (GameManager.Mode == GameManager.GameMode.Play)
        {
            // Get Position
            _horizontal += _direction * Speed * Time.fixedDeltaTime;
            _horizontal = Mathf.Clamp(_horizontal, Clamp.x, Clamp.y);

            // Set Position
            _rigidbody.MovePosition(new Vector3(_horizontal, 0, 0));
        }
    }

    private void Update()
    {
        // Get Input
        if (Input.GetKey(KeyCode.Mouse0))
        {
            float currentMousePosition = Input.mousePosition.x;

            if (_previousInputDown == false)
            {
                _previousMousePosition = currentMousePosition;
            }

            _direction += (currentMousePosition - _previousMousePosition) * Time.deltaTime;
            _direction = Mathf.Clamp(_direction, -1, 1);

            _previousMousePosition = currentMousePosition;
            _previousInputDown = true;
        }
        else
        {
            _direction = 0;
            _previousInputDown = false;
        }
    }
}