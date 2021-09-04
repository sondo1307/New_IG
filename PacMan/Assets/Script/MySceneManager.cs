using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MySceneManager : MonoBehaviour
{
    public static MySceneManager Instance;
    public bool begin;
    public bool allowPlayerToInput;
    public int totalSead { get; set; }

    [Header("Particle")]
    public GameObject bonusScore;
    private void Awake()
    {
        Application.targetFrameRate = 60;
        Instance = this;
        begin = false;
        allowPlayerToInput = false;
        Time.timeScale = 0;
    }

    EnemyMovement[] l;
    private void Start()
    {
        l = FindObjectsOfType<EnemyMovement>();
        totalSead = FindObjectsOfType<Sead>().Length;
    }

    private void Update()
    {
        if (allowPlayerToInput && !begin)
        {
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S)|| Input.GetKeyDown(KeyCode.D)|| Input.GetKeyDown(KeyCode.A))
            {
                Time.timeScale = 1;
                StartCoroutine(DeployEnemy());
                begin = true;
            }
        }
    }

    public IEnumerator DeployEnemy()
    {
        for (int i = 0; i < l.Length; i++)
        {
            l[i].enabled = true;
            yield return new WaitForSeconds(2);
        }
    }
        
    public void MinusTotalSead()
    {
        totalSead--;
        if (totalSead == 0)
        {
            Time.timeScale = 0;
            begin = false;
            InGameUI.Instance.ShowUIWin();
        }
    }

}


