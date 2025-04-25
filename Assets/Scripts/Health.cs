using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] protected int maxHP;
    [SerializeField] protected DamageFlash damageFlash;
    [SerializeField] protected SpriteRenderer spriteRenderer;

    protected int currentHP;

    void Awake()
    {
        currentHP = maxHP;
    }

    public virtual void TakeDamage(int damage)
    {
        currentHP = currentHP - damage;
        StartCoroutine(damageFlash.Damaged(spriteRenderer, 1));
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
