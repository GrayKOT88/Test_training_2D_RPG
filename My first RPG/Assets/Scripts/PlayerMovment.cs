using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private Animator _animator;
    private int _facingDirection = 1;
    
    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if(horizontal > 0 && transform.localScale.x < 0 ||
            horizontal < 0 && transform.localScale.x > 0)
        {
            Flip();
        }

        _animator.SetFloat("horizontal", Mathf.Abs(horizontal));
        _animator.SetFloat("vertical", Mathf.Abs(vertical));

        _rb.velocity = new Vector2(horizontal, vertical) * _speed;
    }

    private void Flip()
    {
        _facingDirection *= -1;
        transform.localScale = new Vector3(transform.localScale.x * -1,
            transform.localScale.y,transform.localScale.z);
    }
}
