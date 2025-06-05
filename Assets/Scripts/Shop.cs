using System;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public GameObject prompt;
    public GameObject shopScreen;
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
        }
    }

    public void OnB()
    {
        if (shopScreen.activeSelf == false && inBuyZone == true)
        {
            shopScreen.SetActive(true);
        }
        else
        {
            shopScreen.SetActive(false);
        }
    }

    public void SetTimeOut(bool to)
    {
        timeOut = to;
    }
}
