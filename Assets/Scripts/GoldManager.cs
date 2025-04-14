using TMPro;
using UnityEngine;

public class GoldManager : MonoBehaviour
{
    public TextMeshProUGUI GoldText;
    private int gold = 0;

    public void AddGold(int i)
    {
        gold = gold + i;
        GoldText.text = gold.ToString();
    }

    public void RemoveGold(int i)
    {
        gold = gold - i;
        GoldText.text = gold.ToString();
    }
}
