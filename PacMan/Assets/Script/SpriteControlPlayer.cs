using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteControlPlayer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            collision.transform.position = transform.position;
            collision.GetComponent<PlayerMovement>().allowToTurn90 = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            collision.GetComponent<PlayerMovement>().allowToTurn90 = true;
        }
        else if (collision.transform.CompareTag("Enemy"))
        {
            //Debug.Log(0);
            //collision.GetComponent<EnemyMovement>().DecideToMove();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            collision.GetComponent<PlayerMovement>().allowToTurn90 = false;
        }
        //else if (collision.transform.CompareTag("Enemy"))
        //{
        //    collision.GetComponent<EnemyMovement>().allow = true;
        //}
    }
}
