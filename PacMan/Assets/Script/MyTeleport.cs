using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyTeleport : MonoBehaviour
{
    public bool isEnterPort;
    public Transform otherPort;
    public bool left;
    public bool allowPlayerToEnter;

    private void Start()
    {
        allowPlayerToEnter = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player") && allowPlayerToEnter)
        {
            if (!otherPort.GetComponent<MyTeleport>().isEnterPort)
            {
                isEnterPort = true;
                otherPort.GetComponent<MyTeleport>().isEnterPort = false;
                collision.transform.position = otherPort.transform.position;
                allowPlayerToEnter = false;
                StartCoroutine(collision.GetComponent<PlayerMovement>().TemporaryDisablePlayerMovement());
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            if (!isEnterPort && otherPort.GetComponent<MyTeleport>().isEnterPort)
            {
                otherPort.GetComponent<MyTeleport>().isEnterPort = false;
                allowPlayerToEnter = true;
            }
        }
    }
}
