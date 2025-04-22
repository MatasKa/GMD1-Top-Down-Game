using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int gold = 1;
    public int damage = 1;
    public float speed = 1f;
    private GameObject player;
    private Rigidbody2D rb;

    private PlayerHealth playerHealth;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.gameObject.GetComponent<PlayerHealth>();
    }

    void FixedUpdate()
    {
        Vector2 direction = (player.transform.position - transform.position).normalized;
        rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);
    }

    void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerHealth.TakeDamage(damage);
            playerHealth.UpdateHealthBar();
        }
    }
}
