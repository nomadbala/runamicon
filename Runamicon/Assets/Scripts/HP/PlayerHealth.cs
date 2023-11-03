using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : Health
{
    public override void TakeDamage(int damage)
    {
#if (UNITY_EDITOR)
        Debug.Log($"mob takes damage {damage}");
#endif
        _currentHealth -= damage;

        Debug.Log(_currentHealth);

        if (_currentHealth <= 0) // Чел сдох или нет
        {
            SceneManager.LoadScene("MainMenuScene");
        }
    }
}
