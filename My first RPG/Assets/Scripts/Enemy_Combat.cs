using UnityEngine;

public class Enemy_Combat : MonoBehaviour
{
    [SerializeField] private int _damage = 1;
    [SerializeField] private Transform _attackPoint;
    [SerializeField] private float _weaponRange;
    [SerializeField] private float _knockbackForce;
    [SerializeField] private float _stunTime;
    [SerializeField] private LayerMask _playerLayer;       

    public void Attack()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(_attackPoint.position, _weaponRange, _playerLayer);
        if (hits.Length > 0 )
        {
            hits[0].GetComponent<PlayerHealth>().ChangeHealth(-_damage);
            hits[0].GetComponent<PlayerMovment>().Knockback(transform, _knockbackForce, _stunTime);
        }
    }
}