using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteControlPlayer : MonoBehaviour
{

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            collision.GetComponent<PlayerMovement>().allowToTurn90 = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            collision.GetComponent<PlayerMovement>().allowToTurn90 = false;
        }
    }
}
