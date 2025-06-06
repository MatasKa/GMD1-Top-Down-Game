using UnityEngine;

public class CharInitialize : MonoBehaviour
{
    public GameObject wardenPrefab;
    public GameObject wolfPrefab;
    public GameObject duelistPrefab;

    void Awake()
    {
        CharacterChoice characterChoice = FindFirstObjectByType<CharacterChoice>();
        if (characterChoice.character == 0)
        {
            Instantiate(wardenPrefab, Vector3.zero, Quaternion.identity);
        }
        else if (characterChoice.character == 1)
        {
            Instantiate(wolfPrefab, Vector3.zero, Quaternion.identity);
        }
        else
        {
            Instantiate(duelistPrefab, Vector3.zero, Quaternion.identity);
        }
    }
}
