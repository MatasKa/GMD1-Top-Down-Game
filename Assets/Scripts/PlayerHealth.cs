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
}
