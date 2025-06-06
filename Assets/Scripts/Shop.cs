using System;
using TMPro;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public GameObject[] weaponShopPrefabs;
    public GameObject[] weaponPrefabs;
    public int[] weaponPrices;
    public GameObject[] potionPrefabs;
    public ShopZone shopZone;
    public GameObject shopCanvas;

    public TextMeshProUGUI weaponPriceText;
    public TextMeshProUGUI rerollPriceText;
    public TextMeshProUGUI playerStatsText;

    private PlayerStats playerStats;
    private PlayerHealth playerHealth;
    private GoldManager goldManager;
    private GameObject currentPlayerWeapon;


    private GameObject CurrentWeapon = null;
    private int CurrentWeaponClass = 0;
    private int CurrentWeaponReq = 6;
    private GameObject CurrentPotion = null;
    private int[] allPlayerStats = new int[3];

    private int rerollPrice = 6;
    private int WeaponNumber;
    private int PotionNumber;
    private bool shopedThisPause = false;
    private bool potionBought = false;
    void Start()
    {
        playerStats = GameObject.FindAnyObjectByType<PlayerStats>();
        playerHealth = GameObject.FindAnyObjectByType<PlayerHealth>();
        goldManager = GameObject.FindAnyObjectByType<GoldManager>();
        currentPlayerWeapon = GameObject.Find("Weapon");
        rerollPriceText.text = rerollPrice.ToString();

        RandomizeShop(true);
    }

    public void setShopedThisPause(bool s)
    {
        shopedThisPause = s;
        rerollPrice = 6;
        rerollPriceText.text = rerollPrice.ToString();
    }

    public void RandomizeShop(bool reroll)
    {
        if (reroll || shopedThisPause == false)
        {
            Destroy(CurrentWeapon);
            Destroy(CurrentPotion);

            WeaponNumber = UnityEngine.Random.Range(0, 9);
            GameObject newWeapon = Instantiate(weaponShopPrefabs[WeaponNumber], shopCanvas.transform);
            weaponPriceText.text = weaponPrices[WeaponNumber].ToString();
            CurrentWeapon = newWeapon;

            if (weaponPrices[WeaponNumber] == 30) { CurrentWeaponReq = 6; }
            else if (weaponPrices[WeaponNumber] == 75) { CurrentWeaponReq = 8; }
            else { CurrentWeaponReq = 10; }

            if (WeaponNumber < 3) { CurrentWeaponClass = 0; } //ward
            else if (WeaponNumber > 5) { CurrentWeaponClass = 2; } //duel
            else { CurrentWeaponClass = 1; }  //wolf

            PotionNumber = UnityEngine.Random.Range(0, 4);
            GameObject newPotion = Instantiate(potionPrefabs[PotionNumber], shopCanvas.transform);
            CurrentPotion = newPotion;
            potionBought = false;
        }
    }

    public void LoadPlayerStats()
    {
        allPlayerStats[0] = playerStats.GetStrength();
        allPlayerStats[1] = playerStats.GetDexterity();
        allPlayerStats[2] = playerStats.GetFinesse();

        playerStatsText.text = "Str " + playerStats.GetStrength() + "\nDex " + playerStats.GetDexterity() + "\nFin " + playerStats.GetFinesse();
    }

    public void OnY()
    {
        if (shopZone.GetTimeOut() && goldManager.GetGold() >= rerollPrice)
        {
            goldManager.RemoveGold(rerollPrice);
            rerollPrice += 2;
            rerollPriceText.text = rerollPrice.ToString();
            RandomizeShop(true);
        }
    }

    public void OnA()
    {
        if (shopZone.shopScreen.activeSelf && goldManager.GetGold() >= int.Parse(weaponPriceText.text))
        {
            if (CurrentWeaponReq <= allPlayerStats[CurrentWeaponClass])
            {
                goldManager.RemoveGold(int.Parse(weaponPriceText.text));
                CurrentWeaponReq = 99;

                Destroy(currentPlayerWeapon.transform.GetChild(0).transform.GetChild(0).gameObject);
                GameObject changedWeapon = Instantiate(weaponPrefabs[WeaponNumber], Vector3.zero, Quaternion.identity, currentPlayerWeapon.transform.GetChild(0));
                changedWeapon.transform.localPosition = Vector3.zero;
                changedWeapon.transform.localRotation = Quaternion.identity;
                Destroy(CurrentWeapon);
            }
        }
    }

    public void OnX()
    {
        if (shopZone.shopScreen.activeSelf && goldManager.GetGold() >= 20 && potionBought == false)
        {
            goldManager.RemoveGold(20);
            potionBought = true;

            if (PotionNumber == 0) { playerHealth.Heal(); }
            else if (PotionNumber == 1) { playerStats.AddStrength(1); }
            else if (PotionNumber == 2) { playerStats.AddDexterity(1); }
            else { playerStats.AddFinesse(1); }
            Destroy(CurrentPotion);
            LoadPlayerStats();
        }
    }


}
