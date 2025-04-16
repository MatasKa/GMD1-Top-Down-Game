using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] protected int maxHP;
    private int currentHP;

    void Start()
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
