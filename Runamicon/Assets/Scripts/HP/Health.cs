using UnityEngine;

public abstract class Health : MonoBehaviour
{
    [SerializeField] public float _maxHealth;

    public float _currentHealth;
    
    private void Start()
    {
        _currentHealth = _maxHealth;
    }

    public abstract void TakeDamage(float damage);
}
