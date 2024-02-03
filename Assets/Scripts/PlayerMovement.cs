using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _jumpForce = 5f;

    private Rigidbody2D _body;
    private bool _canJump = true;

    private void Awake()
    {
        _body = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _body.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * _speed, _body.velocity.y);
        
        //TODO: improve movement. make jump less floaty and make it smoother
        if (Input.GetKey(KeyCode.Space) && _canJump)
        {
            _body.velocity = new Vector2(_body.velocity.x, _jumpForce);
            _canJump = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Assuming the ground has a specific tag, replace "Ground" with your ground tag
        if (collision.gameObject.CompareTag("Ground"))
        {
            _canJump = true;
        }
    }
}