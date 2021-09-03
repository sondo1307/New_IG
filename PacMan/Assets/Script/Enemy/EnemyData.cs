using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyData : MonoBehaviour
{
    public Color normal;
    public Color vulnerable;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public IEnumerator TurnVulnerable()
    {
        spriteRenderer.color = vulnerable;
        yield return new WaitForSeconds(5);
        spriteRenderer.color = normal;
    }
}
