using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerData : MonoBehaviour
{
    [SerializeField] private float superTime;
    private ScoreTxt scoreTxt;
    private Animator animator;

    private void Awake()
    {

    }

    private void Start()
    {
        animator = GetComponent<Animator>();
        scoreTxt = FindObjectOfType<ScoreTxt>();
    }

    public void SetPoint(int a)
    {
        DataManager.Instance.score+=a;
        scoreTxt.SetScoreTxt(DataManager.Instance.score);
    }
    public IEnumerator PowerUp()
    {
        animator.SetLayerWeight(1, 1);
        animator.SetTrigger(GetComponent<PlayerMovement>().lastAnimationTrigger);
        GetComponentInChildren<PlayerSquare>().isSuper = true;
        yield return new WaitForSeconds(superTime);
        animator.SetLayerWeight(1, 0);
        GetComponentInChildren<PlayerSquare>().isSuper = false;
    }


    public IEnumerator KillPlayer()
    {
        animator.SetTrigger("Dead");
        transform.GetChild(0).transform.localPosition = Vector3.zero;
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        GetComponent<PlayerMovement>().enabled = false;
        MySceneManager.Instance.begin = false;
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
        MySceneManager.Instance.begin = false;
        Time.timeScale = 0;
        //Call UI GameOver
        InGameUI.Instance.ShowUILose();
    }


}
