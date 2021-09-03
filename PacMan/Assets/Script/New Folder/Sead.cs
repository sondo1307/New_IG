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
            //if (sead == SeadKind.normal)
            //{
            //    collision.GetComponentInParent<PlayerData>().Point++;
            //}
            //else if (sead == SeadKind.power)
            //{
            //    Debug.Log(0);
            //    StartCoroutine(collision.GetComponentInParent<PlayerData>().PowerUp());
            //}
            StartCoroutine(collision.GetComponentInParent<PlayerData>().PowerUp());
            Destroy(gameObject);
        }
    }
}
