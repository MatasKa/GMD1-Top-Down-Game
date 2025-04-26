using UnityEngine;

public class EnemyHealth : Health
{
    protected override void Die()
    {
        Enemy enemy = GetComponent<Enemy>();
        GoldManager goldManager = FindFirstObjectByType<GoldManager>();
        goldManager.AddGold(enemy.gold);
        base.Die();
    }
}
