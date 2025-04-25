using System.Collections;
using JetBrains.Annotations;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class PlayerHealth : Health
{

    private UnityEngine.UI.Slider healthBar;
    private TextMeshProUGUI HealthText;
    [SerializeField] private float invincibilityDuration = 1f;

    private bool Invincible = false;


    void Start()
    {
        healthBar = GameObject.Find("HealthBar").GetComponent<UnityEngine.UI.Slider>();
        HealthText = GameObject.Find("HPText").GetComponent<TextMeshProUGUI>();
        UpdateHealthBar();
    }
    protected override void Die()
    {
        GameObject deathScreen = GameObject.Find("DeathScreen");
        if (deathScreen != null)
        {
            deathScreen.SetActive(true);
        }
        //base.Die();
    }

    public int GetHealth()
    {
        return base.currentHP;
    }

    public void UpdateHealthBar()
    {
        HealthText.text = currentHP.ToString() + " / " + maxHP.ToString();
        healthBar.value = (float)currentHP / (float)maxHP;
    }

    public override void TakeDamage(int damage)
    {
        if (Invincible == false)
        {
            StartCoroutine(Invincibility());
            StartCoroutine(damageFlash.Damaged(spriteRenderer, 3));
            base.TakeDamage(damage);
        }
    }

    private IEnumerator Invincibility()
    {
        Invincible = true;
        yield return new WaitForSeconds(invincibilityDuration);
        Invincible = false;
    }

}
