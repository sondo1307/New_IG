using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class BonusScoreTxt : MonoBehaviour
{
    public Color one;
    public Color two;
    public TMP_Text txt;

    private void OnEnable()
    {
        txt = GetComponent<TMP_Text>();
    }

    private void Start()
    {
        Sequence s = DOTween.Sequence();
        (s.Append(txt.DOColor(two, 0.25f).SetEase(Ease.Linear).SetUpdate(true))
            .Append(txt.DOColor(one, 0.25f).SetEase(Ease.Linear).SetUpdate(true))).SetLoops(2, LoopType.Restart).SetUpdate(true)
            .OnComplete(()=>Destroy(gameObject));
    }
}
