using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighScoreTxt : MonoBehaviour
{
    private void Start()
    {
        GetComponent<TMP_Text>().SetText("Highscore: " + PlayerPrefs.GetInt("Highscore"));
    }
}
