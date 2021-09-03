using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class InGameUI : MonoBehaviour
{
    public GameObject transPanel;
    public GameObject pauseGroup;

    private void Awake()
    {
        transPanel.SetActive(true);
    }

    private void OnEnable()
    {
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

    public void OnHomeBtnClick()
    {
        transPanel.GetComponent<Image>().DOFade(1, 0.5f).SetEase(Ease.Linear).SetUpdate(true)
            .OnComplete(OnCompleteHomeBtn);
    }

    public void OnCompleteHomeBtn()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
