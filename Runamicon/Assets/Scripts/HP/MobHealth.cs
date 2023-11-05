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

        if (_currentHealth <= 0)
        {
            var mobStateMachine = GetComponent<MobStateMachine>();
            mobStateMachine.isDead = true;
            mobStateMachine.isWalking = false;
            mobStateMachine.isRunning = false;
            mobStateMachine.isAttacking = false;
            mobStateMachine.Target = null;
            mobStateMachine.GetComponent<Collider>().enabled = false;
        }
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
