using UnityEngine;

public class Enemy_Movment : MonoBehaviour
{
    private float _speed = 3f;    
    private int facingDirection = -1;
    private EnemyState _enemyState;

    private Rigidbody2D _rb;
    private Transform _player;
    private Animator _animator;
    
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        ChangeState(EnemyState.Idle);
    }
        
    void FixedUpdate()
    {
        if(_enemyState == EnemyState.Chasing)
        {
            if(_player.position.x > transform.position.x && facingDirection == -1 
                || _player.position.x < transform.position.x && facingDirection == 1)
            {
                Flip();
            } 
            Vector2 direction = (_player.position - transform.position).normalized;
            _rb.velocity = direction * _speed;
        }
    }

    private void Flip()
    {
        facingDirection *= -1;
        transform.localScale = new Vector3(transform.localScale.x * -1,
            transform.localScale.y, transform.localScale.z);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if (_player == null)
            {
                _player = collision.transform;
            }            
            ChangeState(EnemyState.Chasing);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _rb.velocity = Vector2.zero;            
            ChangeState(EnemyState.Idle);
        }
    }

    private void ChangeState(EnemyState newState)
    {
        if (_enemyState == EnemyState.Idle)
            _animator.SetBool("isIdle", false);
        else if (_enemyState == EnemyState.Chasing)
            _animator.SetBool("isChasing", false);

        _enemyState = newState;

        if (_enemyState == EnemyState.Idle)
            _animator.SetBool("isIdle", true);
        else if (_enemyState == EnemyState.Chasing)
            _animator.SetBool("isChasing", true);
    }
}

public enum EnemyState
{
    Idle,
    Chasing,
}
