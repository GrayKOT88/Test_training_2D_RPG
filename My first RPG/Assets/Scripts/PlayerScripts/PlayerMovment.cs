using System.Collections;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{    
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private Animator _animator;
    private int _facingDirection = 1;
    private bool _isKnockedBack;
    public bool isShooting;
    [SerializeField] private Player_Combat _player_Combat;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _player_Combat.Attack();
        }
    }

    void FixedUpdate()
    {
        if (isShooting)
        {
            _rb.velocity = Vector2.zero;
        }
        else if (_isKnockedBack == false)
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            if (horizontal > 0 && transform.localScale.x < 0 ||
                horizontal < 0 && transform.localScale.x > 0)
            {
                Flip();
            }

            _animator.SetFloat("horizontal", Mathf.Abs(horizontal));
            _animator.SetFloat("vertical", Mathf.Abs(vertical));

            _rb.velocity = new Vector2(horizontal, vertical) * StatsManager.Instance.speed;
        }
    }

    private void Flip()
    {
        _facingDirection *= -1;
        transform.localScale = new Vector3(transform.localScale.x * -1,
            transform.localScale.y,transform.localScale.z);
    }

    public void Knockback(Transform enemy, float force, float stunTime)
    {
        _isKnockedBack = true;
        Vector2 direction = (transform.position - enemy.position).normalized;
        _rb.velocity = direction * force;
        StartCoroutine(KnockbackCounter(stunTime));
    }

    IEnumerator KnockbackCounter(float stunTime)
    {
        yield return new WaitForSeconds(stunTime);
        _rb.velocity = Vector2.zero;
        _isKnockedBack = false;
    }
}
