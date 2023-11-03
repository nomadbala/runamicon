using UnityEngine;

public abstract class Health : MonoBehaviour
{
    [SerializeField] public int _maxHealth;

    public int _currentHealth;

    private void Start()
    {
        _currentHealth = _maxHealth;
    }

    public abstract void TakeDamage(int damage);
}
