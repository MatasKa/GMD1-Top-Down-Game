using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHP = 3;
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

    void Die()
    {
        // IMPLEMENT gold and sound
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D player)
    {
        // IMPLEMENT dmg
    }
}
