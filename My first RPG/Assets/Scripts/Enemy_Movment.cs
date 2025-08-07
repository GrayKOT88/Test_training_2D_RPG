using UnityEngine;

public class Enemy_Movment : MonoBehaviour
{
    private float _speed = 3f;
    private float _attackRange = 1.2f;
    private float _attackCooldown = 2;

    [SerializeField] private float _playerDetectRange = 5;
    [SerializeField] private Transform _detectionPoint;
    [SerializeField] private LayerMask _playerLayer;

    private float _attackCooldownTimer;
    private int _facingDirection = -1;

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
        
    void Update()
    {
        CheckForPlayer();
        if(_attackCooldownTimer > 0)
        {            
            _attackCooldownTimer -= Time.deltaTime;
        }
        if(_enemyState == EnemyState.Chasing)
        {
            Chase();
        }
        else if(_enemyState == EnemyState.Attacking)
        {
            _rb.velocity = Vector2.zero;
        }
    }

    private void Chase()
    {        
        if(_player.position.x > transform.position.x && _facingDirection == -1 
                || _player.position.x < transform.position.x && _facingDirection == 1)
        {
            Flip();
        } 
        Vector2 direction = (_player.position - transform.position).normalized;
        _rb.velocity = direction * _speed;
    }

    private void Flip()
    {
        _facingDirection *= -1;
        transform.localScale = new Vector3(transform.localScale.x * -1,
            transform.localScale.y, transform.localScale.z);
    }

    private void CheckForPlayer()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll
            (_detectionPoint.position, _playerDetectRange, _playerLayer);
        if(hits.Length > 0 )
        {
            _player = hits[0].transform;

            if(Vector2.Distance(transform.position, _player.position)
                < _attackRange && _attackCooldownTimer <= 0)
            {
                _attackCooldownTimer = _attackCooldown;
                ChangeState(EnemyState.Attacking);
            }
            else if(Vector2.Distance(transform.position, _player.position)
                > _attackRange && _enemyState != EnemyState.Attacking)
            {
                ChangeState(EnemyState.Chasing);
            }                
        }
        else
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
        else if (_enemyState == EnemyState.Attacking)
            _animator.SetBool("isAttacking", false);

        _enemyState = newState;

        if (_enemyState == EnemyState.Idle)
            _animator.SetBool("isIdle", true);
        else if (_enemyState == EnemyState.Chasing)
            _animator.SetBool("isChasing", true);
        else if (_enemyState == EnemyState.Attacking)
            _animator.SetBool("isAttacking", true);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_detectionPoint.position, _playerDetectRange);
    }
}

public enum EnemyState
{
    Idle,
    Chasing,
    Attacking,
}
