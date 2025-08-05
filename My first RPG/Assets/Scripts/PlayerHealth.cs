using TMPro;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int _currentHealth;
    [SerializeField] private int _maxHealth;
    [SerializeField] private TMP_Text _healthText;
    [SerializeField] private Animator _healthTextAnim;

    private void Start()
    {
        _healthText.text = "HP: " + _currentHealth + " / " + _maxHealth;
    }

    public void ChangeHealth(int health)
    {
        _currentHealth += health;
        _healthTextAnim.Play("Text Update");

        _healthText.text = "HP: " + _currentHealth + " / " + _maxHealth;

        if (_currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}