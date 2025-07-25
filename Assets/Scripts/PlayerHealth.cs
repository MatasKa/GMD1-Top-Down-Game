using System.Collections;
using JetBrains.Annotations;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;


public class PlayerHealth : Health
{

    private UnityEngine.UI.Slider healthBar;
    private TextMeshProUGUI HealthText;
    [SerializeField] private float invincibilityDuration = 1f;
    private AudioSource audioSource;


    private bool Invincible = false;


    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        healthBar = GameObject.Find("HealthBar").GetComponent<UnityEngine.UI.Slider>();
        HealthText = GameObject.Find("HPText").GetComponent<TextMeshProUGUI>();
        UpdateHealthBar();
    }
    protected override void Die()
    {
        SceneManager.LoadScene("Lose");
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
            audioSource.Play();
            StartCoroutine(Invincibility());
            StartCoroutine(damageFlash.Damaged(spriteRenderer, 3));
            base.TakeDamage(damage);
        }
    }

    public void Heal()
    {
        currentHP = maxHP;
        UpdateHealthBar();
    }

    private IEnumerator Invincibility()
    {
        Invincible = true;
        yield return new WaitForSeconds(invincibilityDuration);
        Invincible = false;
    }

}
