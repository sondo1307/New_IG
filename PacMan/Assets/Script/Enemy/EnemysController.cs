using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemysController : MonoBehaviour
{

    public static EnemysController Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void TurnAllEnemyWeak()
    {
        StopAllCoroutines();
        EnemyData[] l = FindObjectsOfType<EnemyData>();
        for (int i = 0; i < l.Length; i++)
        {
            StartCoroutine(l[i].TurnVulnerable());
        }
    }
}
