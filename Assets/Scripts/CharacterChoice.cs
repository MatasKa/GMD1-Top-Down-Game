using Unity.VisualScripting;
using UnityEngine;

public class CharacterChoice : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    public int character { get; set; }
}
