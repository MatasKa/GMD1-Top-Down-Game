using UnityEngine;

public class Shop : MonoBehaviour
{
    public GameObject prompt;
    public GameObject shopScreen;
    private bool InBuyZone = false;
    private bool TimeOut = true;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (TimeOut == true)
        {
            InBuyZone = true;
            prompt.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        InBuyZone = false;
        prompt.SetActive(false);
        shopScreen.SetActive(false);
    }

    public void OnB()
    {
        if (shopScreen.activeSelf == false && InBuyZone == true)
        {
            shopScreen.SetActive(true);
        }
        else
        {
            shopScreen.SetActive(false);
        }
    }
}
