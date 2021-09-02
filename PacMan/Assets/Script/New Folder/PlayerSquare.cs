using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSquare : MonoBehaviour
{
    public bool isSuper;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Enemy"))
        {
            if (!isSuper)
            {
                GetComponentInParent<PlayerData>().KillPlayer();
            }
            else
            {
                //Kill Enemy
            }
        }
    }
}
