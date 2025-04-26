using UnityEngine;

public class Bullet : MonoBehaviour
{
    private PlayerHealth playerHealth;
    //private Rigidbody2D rb;
    public int damage = 1;

    void Start()
    {
        //rb = GetComponent<Rigidbody2D>();
        playerHealth = GameObject.FindGameObjectWithTag("Player").gameObject.GetComponent<PlayerHealth>();
    }
    void FixedUpdate()
    {
        transform.Translate(Vector3.up * 2f * Time.deltaTime);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerHealth.TakeDamage(damage);
            playerHealth.UpdateHealthBar();
            Destroy(gameObject);
        }
    }
}
