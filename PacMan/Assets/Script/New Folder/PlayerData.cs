using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    [SerializeField] private float point;
    [SerializeField] private float superTime;
    [SerializeField] private RuntimeAnimatorController normal;
    [SerializeField] private RuntimeAnimatorController super;
    

    private void Start()
    {
    }

    public float Point { get => point; set => point = value; }

    public IEnumerator PowerUp()
    {
        Debug.Log(1);
        //GetComponentInChildren<PlayerSquare>().isSuper = true;
        yield return new WaitForSeconds(superTime);
        //GetComponentInChildren<PlayerSquare>().isSuper = false;
        Debug.Log(2);
    }

    public IEnumerator KillPlayer()
    {
        Instantiate(MySceneManager.Instance.deadParticle, transform.position, Quaternion.identity);
        Destroy(gameObject);
        yield return new WaitForSeconds(2);
        Time.timeScale = 0;
        //Call UI GameOver
    }
}
