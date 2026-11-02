
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField]
    private string _horziontalAxis = "Horizontal", _verticalAxis = "Vertical";

    [SerializeField]
    private Rigidbody2D _rb2D;

    private Vector2 _input;

    [SerializeField]
    private float _speed = 3f;

    public UnityEvent OnPlayerDie;

    private void FixedUpdate()
    {
        _rb2D.linearVelocity = _input * _speed;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxisRaw(_horziontalAxis);
        float verticalInput = Input.GetAxisRaw(_verticalAxis);

        _input = new Vector2(horizontalInput, verticalInput);
        _input.Normalize();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (OnPlayerDie != null)
        {
            OnPlayerDie.Invoke();
        }

        Destroy(gameObject);
    }
}
