using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMenu : MonoBehaviour
{
    void OnA()
    {
        SceneManager.LoadScene("Menu");
    }

}
