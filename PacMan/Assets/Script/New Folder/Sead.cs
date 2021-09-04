using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sead : MonoBehaviour
{
    public enum SeadKind
    {
        normal,
        power,
    };

    public SeadKind sead;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("PlayerSquare"))
        {
            MySceneManager.Instance.MinusTotalSead();
            Destroy(gameObject);
        }
    }
}
