using UnityEngine;
using UnityEngine.SceneManagement;

public class EndManager : MonoBehaviour
{
    public GameObject[] bossLegs;
    void Update()
    {
        if (bossLegs[0] == null && bossLegs[1] == null && bossLegs[2] == null && bossLegs[3] == null)
        {
            SceneManager.LoadScene("End");
        }
    }
}
