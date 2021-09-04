using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class InGameUI : MonoBehaviour
{
    public static InGameUI Instance;

    public GameObject transPanel;
    public GameObject pauseGroup;
    public GameObject winGroup;
    public GameObject loseGroup;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void OnEnable()
    {
        transPanel.SetActive(true);
        transPanel.GetComponent<Image>().DOFade(0, 0.5f).SetEase(Ease.Linear).SetUpdate(true)
         .OnComplete(() => MySceneManager.Instance.allowPlayerToInput = true);
    }

    public void OnPauseBtnClick()
    {
        Time.timeScale = 0;
        pauseGroup.SetActive(true);
    }

    public void OnResumeBtnClick()
    {
        Time.timeScale = 1;
        pauseGroup.SetActive(false);
    }

    public void OnRestartBtnClick()
    {
        DataManager.Instance.ResetData();
        SceneManager.LoadScene(1);
    }

    public void OnHomeBtnClick()
    {
        DataManager.Instance.SaveData();
        DataManager.Instance.ResetData();
        transPanel.GetComponent<Image>().DOFade(1, 0.5f).SetEase(Ease.Linear).SetUpdate(true)
            .OnComplete(OnCompleteHomeBtn);
    }

    public void OnNextLevelBtnClick()
    {
        SceneManager.LoadScene(1);
    }

    public void OnCompleteHomeBtn()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void ShowUIWin()
    {
        winGroup.SetActive(true);
    }

    public void ShowUILose()
    {
        loseGroup.SetActive(true);
    }
}
