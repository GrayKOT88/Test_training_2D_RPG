using UnityEngine;

public class Enemy_Health : MonoBehaviour
{
    public int expReward = 3;
    public delegate void MonsterDefeated(int exp);
    public static event MonsterDefeated OnMonsterDefeated;

    [SerializeField] private int _currentHealth;
    [SerializeField] private int _maxHealth;    

    private void Start()
    {
        _currentHealth = _maxHealth;
    }

    public void ChangeHealth(int health)
    {
        _currentHealth += health;
        
        if(_currentHealth > _maxHealth)
        {
            _currentHealth = _maxHealth;
        }
        else if (_currentHealth <= 0)
        {
            OnMonsterDefeated(expReward);
            Destroy(gameObject);
        }
    }
}
