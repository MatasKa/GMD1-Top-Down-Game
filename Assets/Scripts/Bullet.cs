using UnityEngine;

public class Bullet : MonoBehaviour
{
    private PlayerHealth playerHealth;
    public int damage = 1;

    void Start()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").gameObject.GetComponent<PlayerHealth>();
        Destroy(gameObject, 15f);
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
