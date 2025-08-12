using UnityEngine;

public class Player_Combat : MonoBehaviour
{
    [SerializeField] private Transform _attackPoint;    
    [SerializeField] private LayerMask _enemyLayer;    

    [SerializeField] private Animator _animator;
    [SerializeField] private float _cooldown = 2f;
    private float _timer;

    private void Update()
    {
        if(_timer > 0)
        {
            _timer -= Time.deltaTime;
        }
    }

    public void Attack()
    {
        if (_timer <= 0)
        {
            _animator.SetBool("isAttacking", true);
            _timer = _cooldown;
        }
    }

    public void DealDamage()
    {
        Collider2D[] enemis = Physics2D.OverlapCircleAll(_attackPoint.position, StatsManager.Instance.weaponRange, _enemyLayer);
        if (enemis.Length > 0)
        {
            enemis[0].GetComponent<Enemy_Health>().ChangeHealth(-StatsManager.Instance.damage);
            enemis[0].GetComponent <Enemy_Knockback>().Knockback(transform, StatsManager.Instance.knockbackForce, StatsManager.Instance.knockbackTime, StatsManager.Instance.stunTime);
        }
    }

    public void FinishAttacking()
    {
        _animator.SetBool("isAttacking", false);
    }

    /*private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_attackPoint.position, StatsManager.Instance.weaponRange);
    }*/
}
