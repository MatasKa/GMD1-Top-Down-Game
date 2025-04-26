using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    private bool PlayerClose = false;
    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "AntiSpawn")
        {
            PlayerClose = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "AntiSpawn")
        {
            PlayerClose = false;
        }
    }

    public bool IsPlayerClose()
    {
        return PlayerClose;
    }
}
