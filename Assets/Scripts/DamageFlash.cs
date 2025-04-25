using System.Collections;
using UnityEngine;

public class DamageFlash : MonoBehaviour
{
    public IEnumerator Damaged(SpriteRenderer spriteRenderer, int flashes)
    {
        for (int i = 0; i < flashes; i++)
        {
            yield return new WaitForSeconds(0.15f);
            spriteRenderer.color = Color.red;
            yield return new WaitForSeconds(0.15f);
            spriteRenderer.color = Color.white;
        }
    }
}
