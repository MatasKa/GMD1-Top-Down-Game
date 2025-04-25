using UnityEngine;

public class FacePlayer : MonoBehaviour
{
    private Transform player;
    [SerializeField] private float rotationSpeed = 1f;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (player != null)
        {
            Vector3 dir = player.position - transform.position;
            float targetAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            float angle = Mathf.LerpAngle(transform.eulerAngles.z, targetAngle - 90f, rotationSpeed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }
}
