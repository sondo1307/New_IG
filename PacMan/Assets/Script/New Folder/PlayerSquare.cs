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
                StartCoroutine(GetComponentInParent<PlayerData>().KillPlayer());
            }
            else
            {
                //Kill Enemy
                Instantiate(MySceneManager.Instance.bonusScore, transform.position, Quaternion.identity);
                StartCoroutine(collision.GetComponent<EnemyMovement>().ReturnToBase());
                GetComponentInParent<PlayerData>().SetPoint(1000);
            }
        }
        else if (collision.transform.CompareTag("Sead"))
        {
            if (collision.GetComponent<Sead>().sead == Sead.SeadKind.normal)
            {
                GetComponentInParent<PlayerData>().SetPoint(10);
                AudioManager.Instance.PlayAudio("Sead");
            }
            else if (collision.GetComponent<Sead>().sead == Sead.SeadKind.power)
            {
                StopAllCoroutines();
                EnemysController.Instance.TurnAllEnemyWeak();
                GetComponentInParent<PlayerData>().SetPoint(100);
                StartCoroutine(GetComponentInParent<PlayerData>().PowerUp());
                AudioManager.Instance.PlayAudio("Power");
            }
        }
    }
}
