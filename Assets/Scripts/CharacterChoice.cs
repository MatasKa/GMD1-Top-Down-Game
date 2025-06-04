using Unity.VisualScripting;
using UnityEngine;

public class CharacterChoice : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    public int str { get; set; }
    public int dex { get; set; }
    public int fin { get; set; }
    public int speed { get; set; }
    public int sprite { get; set; }
    public void SetCharStats(int s, int d, int f, int spd, int spr)
    {
        str = s;
        dex = d;
        fin = f;
        speed = spd;
        sprite = spr;
    }
}
