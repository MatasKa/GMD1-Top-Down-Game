using UnityEngine;

public class EnemyHealth : Health
{
    public GameObject hitEffect;
    public GameObject killEffect;
    protected override void Die()
    {
        Enemy enemy = GetComponent<Enemy>();
        GoldManager goldManager = FindFirstObjectByType<GoldManager>();
        goldManager.AddGold(enemy.gold);
        Instantiate(killEffect, transform.position, Quaternion.identity);
        base.Die();
    }

    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        Instantiate(hitEffect, transform.position, Quaternion.identity);
    }
}
