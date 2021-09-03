using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private LayerMask wallLayer;
    [SerializeField] private LayerMask turnLayer;
    [SerializeField] private LayerMask playerLayer;
    private List<Vector3> dirNoHitWall;
    private Rigidbody2D rb;
    [SerializeField] protected Transform aheadPoint;
    [SerializeField] private float moveSpeed;

    public Vector3 nextTurnPos;
    public Vector3 lastTurnPos;
    public bool allow;
    protected Animator animator;
    private SpriteRenderer spriteRenderer;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        dirNoHitWall = new List<Vector3>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {

        allow = true;
        Sequence s = DOTween.Sequence();

        s.Append(transform.DOMove(new Vector3(11.5f, 11.5f, 0), 0.5f).SetEase(Ease.Linear))
            .Append(transform.DOMoveY(13.5f, 1f).SetEase(Ease.Linear).OnComplete(DecideToMove));
    }

    private void Start()
    {
    }

    private void FixedUpdate()
    {
        TurnCheck();
        CheckPlayerAhead();
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, nextTurnPos) <= 0.05f && Vector3.Distance(transform.position, nextTurnPos) > 0)
        {
            transform.position = nextTurnPos;
            allow = false;
            DecideToMove();
            lastTurnPos = transform.position;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(ReturnToBase());
        }

    }

    private void LateUpdate()
    {
        rb.velocity = (aheadPoint.position - transform.position).normalized * moveSpeed;
    }

    private void ScanFourDir()
    {
        for (int i = 0; i < 4; i++)
        {
            if (i==0)
            {
                if (!Physics2D.Raycast(transform.position, transform.right, 0.525f, wallLayer))
                {
                    RaycastHit2D a = Physics2D.Raycast(transform.position + transform.right, transform.right, 23f, turnLayer);
                    if (a.point != Vector2.zero && a.collider.transform.position != lastTurnPos)
                    {
                        dirNoHitWall.Add(transform.right);
                    }
                    //dirNoHitWall.Add(transform.right);
                }
            }
            else if (i ==1)
            {
                if (!Physics2D.Raycast(transform.position, -transform.right, 0.525f, wallLayer))
                {
                    RaycastHit2D a = Physics2D.Raycast(transform.position - transform.right, -transform.right, 23f, turnLayer);
                    if (a.point != Vector2.zero && a.collider.transform.position != lastTurnPos)
                    {
                        dirNoHitWall.Add(-transform.right);

                    }
                    //dirNoHitWall.Add(-transform.right);

                }
            }
            else if (i==2)
            {
                if (!Physics2D.Raycast(transform.position, -transform.up, 0.525f, wallLayer))
                {
                    RaycastHit2D a = Physics2D.Raycast(transform.position - transform.up, -transform.up, 23f, turnLayer);
                    if (a.point != Vector2.zero && a.collider.transform.position != lastTurnPos)
                    {
                        dirNoHitWall.Add(-transform.up);
                    }
                    //dirNoHitWall.Add(-transform.up);
                }
            }
            else if (i==3)
            {
                if (!Physics2D.Raycast(transform.position, transform.up, 0.525f, wallLayer))
                {
                    RaycastHit2D a = Physics2D.Raycast(transform.position + transform.up, transform.up, 23f, turnLayer);
                    if (a.point != Vector2.zero && a.collider.transform.position != lastTurnPos)
                    {
                        dirNoHitWall.Add(transform.up);
                    }
                    //dirNoHitWall.Add(transform.up);
                }
            }
        }
    }

    bool oneTime;
    private void DecideToMove()
    {
        dirNoHitWall.Clear();
        ScanFourDir();
        int a = Random.Range(0, dirNoHitWall.Count);
        aheadPoint.localPosition = dirNoHitWall[a] * 0.5f;
        if (dirNoHitWall[a] == Vector3.right)
        {
            animator.SetTrigger("TurnRight");
        }
        else if (dirNoHitWall[a] == Vector3.left)
        {
            animator.SetTrigger("TurnLeft");
        }
        else if (dirNoHitWall[a] == Vector3.down)
        {
            animator.SetTrigger("TurnDown");
        }
        else if (dirNoHitWall[a] == Vector3.up)
        {
            animator.SetTrigger("TurnUp");
        }
    }


    RaycastHit2D hit;
    private void TurnCheck()
    {
        hit = Physics2D.Raycast(transform.position, aheadPoint.position - transform.position, 0.55f, turnLayer);
        if (hit)
        {
            nextTurnPos = hit.collider.transform.position;
        }
    }

    public IEnumerator ReturnToBase()
    {
        Time.timeScale = 0;
        GetComponent<EnemyMovement>().enabled = false;
        aheadPoint.localPosition = Vector3.zero;
        spriteRenderer.DOFade(0.3f, 0).SetUpdate(true);
        if (transform.position.y > 11.5f)
        {
            animator.SetTrigger("TurnDown");
        }
        else if (transform.position.y > 11.5f)
        {
            animator.SetTrigger("TurnUp");
        }
        Tween a = transform.DOMove(new Vector3(11.5f, 11.5f, 0), Vector3.Distance(transform.position, new Vector3(11.5f, 11.5f, 0))/8)
            .SetEase(Ease.Linear)
            .SetUpdate(true);
        yield return a.WaitForCompletion();
        animator.SetTrigger("TurnUp");
        nextTurnPos = Vector3.zero;
        lastTurnPos = Vector3.zero;
        spriteRenderer.DOFade(1, 0).SetUpdate(true);
        GetComponent<EnemyMovement>().enabled = true;
        Time.timeScale = 1;
    }

    public void CheckPlayerAhead()
    {
        if (Physics2D.Raycast(transform.position, aheadPoint.position - transform.position, 4f, playerLayer))
        {
            moveSpeed = 4f;
        }
        else
        {
            moveSpeed = 3;
        }
    }
}
