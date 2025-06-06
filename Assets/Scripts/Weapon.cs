using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int damage = 2;
    public float speed = 200;
    void Start()
    {
        GameObject spinSpeedObject = transform.parent.parent.gameObject;
        Spin spin = spinSpeedObject.GetComponent<Spin>();
        spin.setSpeed(speed);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            EnemyHealth enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();
            enemyHealth.TakeDamage(damage);
        }
    }
}
