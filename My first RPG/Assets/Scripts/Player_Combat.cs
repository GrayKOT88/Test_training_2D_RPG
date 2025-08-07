using UnityEngine;

public class Player_Combat : MonoBehaviour
{
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

    public void FinishAttacking()
    {
        _animator.SetBool("isAttacking", false);
    }
}
