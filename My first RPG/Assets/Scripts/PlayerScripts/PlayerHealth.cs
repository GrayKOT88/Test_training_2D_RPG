using TMPro;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{    
    [SerializeField] private TMP_Text _healthText;
    [SerializeField] private Animator _healthTextAnim;

    private void Start()
    {
        _healthText.text = "HP: " + StatsManager.Instance.currentHealth + " / " + StatsManager.Instance.maxHealth;
    }

    public void ChangeHealth(int health)
    {
        StatsManager.Instance.currentHealth += health;
        _healthTextAnim.Play("Text Update");

        _healthText.text = "HP: " + StatsManager.Instance.currentHealth + " / " + StatsManager.Instance.maxHealth;

        if (StatsManager.Instance.currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}