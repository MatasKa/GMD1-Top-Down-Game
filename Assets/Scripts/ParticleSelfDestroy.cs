using UnityEngine;

public class ParticleSelfDestroy : MonoBehaviour
{
    // Script for particle game objects to commit seppuku after the particles finish
    void Start()
    {
        Destroy(gameObject, 1f);
    }
}
