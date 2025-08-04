using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int _currentHealth;
    [SerializeField] private int _maxHealth;

    public void ChangeHealth(int health)
    {
        _currentHealth += health;
        if(_currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}