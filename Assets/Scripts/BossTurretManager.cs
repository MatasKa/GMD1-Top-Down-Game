using System.Collections;
using UnityEngine;

public class BossTurretManager : MonoBehaviour
{
    [SerializeField] private float stateChangeTime;
    [SerializeField] private Spin spinScript;
    [SerializeField] private FacePlayer facePlayerScript;

    [SerializeField] private ShootBullets MainTurret;
    [SerializeField] private ShootBullets[] OtherTurrets;
    void Start()
    {
        StartCoroutine(AttackPlayer());
    }

    private IEnumerator AttackPlayer()
    {
        MainTurret.shootInterval = 0.25f;
        spinScript.enabled = false;
        facePlayerScript.enabled = true;

        for (int i = 0; i < 3; i++)
        {
            OtherTurrets[i].shootInterval = stateChangeTime;
        }
        yield return new WaitForSeconds(stateChangeTime);
        StartCoroutine(AttackRotate());
    }

    private IEnumerator AttackRotate()
    {
        MainTurret.shootInterval = 0.4f;
        spinScript.enabled = true;
        facePlayerScript.enabled = false;

        for (int i = 0; i < 3; i++)
        {
            OtherTurrets[i].shootInterval = 0.4f;
        }
        yield return new WaitForSeconds(stateChangeTime * 2);
        StartCoroutine(AttackPlayer());
    }
}
