using TMPro;
using UnityEngine;

public class GoldManager : MonoBehaviour
{
    private TextMeshProUGUI GoldText;
    private int gold = 0;

    void Start()
    {
        GoldText = GameObject.Find("Gold Text").GetComponent<TextMeshProUGUI>();
    }

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
