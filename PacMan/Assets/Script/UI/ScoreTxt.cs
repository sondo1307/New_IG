using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreTxt : MonoBehaviour
{
    private void Start()
    {
        GetComponent<TMP_Text>().SetText("Score: " + DataManager.Instance.score);
    }

    public void SetScoreTxt(int a)
    {
        GetComponent<TMP_Text>().SetText("Score: " + a);
    }
}
