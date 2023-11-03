using System.Text;
using UnityEngine;

public class MobHealth : Health
{
    [SerializeField] private Transform _attackPoint;

    public override void TakeDamage(int damage)
    {
#if (UNITY_EDITOR)
        Debug.Log($"player take damage {damage}");
        Debug.Log(_currentHealth);
#endif

        _currentHealth -= damage;
    }

    public void DealDamage(int damage)
    {
        Collider[] objects = Physics.OverlapSphere(_attackPoint.position, 2);

        PlayerHealth playerHealth = null;

        foreach (var obj in objects)
        {
            playerHealth = obj.GetComponentInChildren<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
            };
            playerHealth = null;
        }
    }
}
