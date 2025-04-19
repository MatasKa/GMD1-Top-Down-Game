using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] protected int maxHP;
    protected int currentHP;

    void Awake()
    {
        currentHP = maxHP;
    }

    public void TakeDamage(int damage)
    {
        currentHP = currentHP - damage;
        if (currentHP <= 0)
        {
            Die();
        }
    }

    protected virtual void Die()
    {
        Destroy(gameObject);
    }
}
