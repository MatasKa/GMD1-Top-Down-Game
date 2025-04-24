using UnityEngine;

public class ShootBullets : MonoBehaviour
{
    public GameObject BulletPrefab;
    public float shootInterval = 0.5f;
    void Start()
    {
        InvokeRepeating("ShootBullet", 0.5f, shootInterval);
    }

    void ShootBullet()
    {
        Instantiate(BulletPrefab, transform.position + transform.up * 0.2f, transform.rotation);
    }
}
