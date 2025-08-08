using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Knockback : MonoBehaviour
{
    private Rigidbody2D _rb;
    private Enemy_Movment _enemy_Movment;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _enemy_Movment = GetComponent<Enemy_Movment>();
    }

    public void Knockback(Transform playerTransform, float knockbackForce, float knockbackTime, float stunTime)
    {
        _enemy_Movment.ChangeState(EnemyState.Knocback);
        StartCoroutine(StunTimer(knockbackTime, stunTime));
        Vector2 direction = (transform.position - playerTransform.position).normalized;
        _rb.velocity = direction * knockbackForce;
    }

    IEnumerator StunTimer(float knockbackTime, float stunTime)
    {
        yield return new WaitForSeconds(knockbackTime);
        _rb.velocity = Vector2.zero;
        yield return new WaitForSeconds(stunTime);
        _enemy_Movment.ChangeState(EnemyState.Idle);
    }
}
