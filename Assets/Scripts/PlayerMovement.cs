using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private AudioClip jumpSFX;
    [SerializeField] private AudioClip landingSFX;

    private Rigidbody2D _body;
    private bool _canJump = true;

    private Animator _animator;

    private void Awake()
    {
        _body = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (!LevelManager.isGameOver)
        {
            _body.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * speed, _body.velocity.y);
            if (Input.GetAxisRaw("Horizontal") < 0)
            {
                _animator.SetInteger("animState", 1);
                gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
            }
            else if (Input.GetAxisRaw("Horizontal") > 0)
            {
                _animator.SetInteger("animState", 1);
                gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else
            {
                _animator.SetInteger("animState", 0);
            }

            //TODO: improve movement. make jump less floaty and make it smoother
            if (Input.GetKey(KeyCode.Space) && _canJump)
            {
                _body.velocity = new Vector2(_body.velocity.x, jumpForce);
                _canJump = false;
                AudioSource.PlayClipAtPoint(jumpSFX, Camera.main.transform.position, 0.1f);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            if (!_canJump)
            {
                AudioSource.PlayClipAtPoint(landingSFX, Camera.main.transform.position, 0.05f);
            }
            _canJump = true;
        }
    }
}