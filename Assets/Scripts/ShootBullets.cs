using System.Collections;
using UnityEngine;

public class ShootBullets : MonoBehaviour
{
    public GameObject BulletPrefab;
    public float shootInterval = 0.5f;
    void Start()
    {
        StartCoroutine("ShootBullet");
    }

    private IEnumerator ShootBullet()
    {
        Instantiate(BulletPrefab, transform.position + transform.up * 0.2f, transform.rotation);
        yield return new WaitForSeconds(shootInterval);
        StartCoroutine("ShootBullet");
    }
}
