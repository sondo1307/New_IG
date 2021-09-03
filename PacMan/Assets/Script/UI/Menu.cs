using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject startBtn;
    public GameObject panel;

    public void OnStartBtnClick()
    {
        panel.SetActive(true);
        panel.GetComponent<Image>().DOFade(1, 0.5f).SetEase(Ease.Linear).OnComplete(() => SceneManager.LoadScene(1));
        //StartCoroutine(Delay());
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(1);
    }
}

