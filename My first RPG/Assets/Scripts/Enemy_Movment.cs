using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Movment : MonoBehaviour
{
    private float _speed = 3f;
    private bool _isChasing;
    private Rigidbody2D _rb;
    private Transform _player;
    
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
        
    void FixedUpdate()
    {
        if(_isChasing == true)
        {
            Vector2 direction = (_player.position - transform.position).normalized;
            _rb.velocity = direction * _speed;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if (_player == null)
            {
                _player = collision.transform;
            }
            _isChasing = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _rb.velocity = Vector2.zero;
            _isChasing = false;
        }
    }
}
