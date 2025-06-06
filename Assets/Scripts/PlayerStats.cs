using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int strength = 0;
    public int dexterity = 0;
    public int finesse = 0;

    public int GetStrength()
    {
        return strength;
    }

    public int GetDexterity()
    {
        return dexterity;
    }

    public int GetFinesse()
    {
        return finesse;
    }

    public void AddFinesse(int add)
    {
        finesse = finesse + add;
    }
    public void AddDexterity(int add)
    {
        dexterity = dexterity + add;
    }
    public void AddStrength(int add)
    {
        strength = strength + add;
    }
}
