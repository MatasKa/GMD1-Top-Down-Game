using UnityEngine;

public class PlayerHealth : Health
{
    protected override void Die()
    {
        GameObject deathScreen = GameObject.Find("DeathScreen");
        if (deathScreen != null)
        {
            deathScreen.SetActive(true);
        }
        base.Die();
    }

    public int GetHealth()
    {
        return base.currentHP;
    }
}
