using System;
using UnityEngine;

public class ShopZone : MonoBehaviour
{
    public GameObject prompt;
    public GameObject nextWavePrompt;
    public GameObject shopScreen;
    public Shop shop;
    private bool inBuyZone = false;
    private bool timeOut = true;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (timeOut == true && other.gameObject.tag == "Player")
        {
            inBuyZone = true;
            prompt.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            inBuyZone = false;
            prompt.SetActive(false);
            shopScreen.SetActive(false);
            if (timeOut)
            {
                nextWavePrompt.SetActive(true);
            }
        }
    }

    public void OnB()
    {
        if (shopScreen.activeSelf == false && inBuyZone == true && GetTimeOut())
        {
            shop.LoadPlayerStats();
            shopScreen.SetActive(true);
            nextWavePrompt.SetActive(false);
        }
        else
        {
            shopScreen.SetActive(false);
            if (timeOut)
            {
                nextWavePrompt.SetActive(true);
            }
        }
    }

    public void OnY()
    {
        if (shopScreen.activeSelf == false)
        {
            SetTimeOut(false);
            shop.ResetShop();
        }
    }

    public bool GetTimeOut()
    {
        return timeOut;
    }
    public void SetTimeOut(bool to)
    {
        timeOut = to;

    }
}
