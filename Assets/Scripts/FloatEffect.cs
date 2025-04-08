using UnityEngine;

public class FloatEffect : MonoBehaviour
{
    public float floatStrength = 0.2f;
    public float floatSpeed = 1.5f;

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        float newY = startPos.y + Mathf.Sin(Time.time * floatSpeed) * floatStrength;
        transform.position = new Vector3(startPos.x, newY, startPos.z);
    }

}
