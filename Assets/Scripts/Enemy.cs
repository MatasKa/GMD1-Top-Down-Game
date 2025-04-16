using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int gold = 1;
    public int damage = 1;

    private GoldManager goldManager;
    private Health health;
    private GameObject player;
    private Health playerHealth;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.gameObject.GetComponent<Health>();
        goldManager = player.gameObject.GetComponent<GoldManager>();
    }

    //goldManager.AddGold(gold);

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerHealth.TakeDamage(damage);
        }
        // IMPLEMENT dmg
    }
}
