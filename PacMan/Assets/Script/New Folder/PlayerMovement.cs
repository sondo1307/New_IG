using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] Rigidbody2D rb;

    Vector2 movement;
    public bool allowToTurn90;
    [SerializeField] private Transform aheadPoint;
    private Vector3 pointVector;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    public bool allowToMove { get; set; }

    public Transform AheadPoint { get => aheadPoint; set => aheadPoint = value; }

    public string lastAnimationTrigger { get; set; }
    private void Start()
    {
        allowToTurn90 = false;
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        allowToMove = true;
    }

    private void Update()
    {
        pointVector = aheadPoint.position - transform.position;
    }

    private void FixedUpdate()
    {
        if (MySceneManager.Instance.begin && allowToMove)
        {
            Movement();
        }
    }
    public void Movement()
    {
        if (Input.GetAxisRaw("Horizontal")!=0)
        {
            if (!FireRay(new Vector3(transform.position.x + Input.GetAxisRaw("Horizontal"), transform.position.y, 0) - transform.position))
            {
                if (Vector3.Angle(rayCastDir, pointVector) != 90)
                {
                    AheadPoint.localPosition = transform.right * Input.GetAxisRaw("Horizontal") * 0.5f;
                    if ((aheadPoint.position - transform.position).x > 0)
                    {
                        PlayAnimation("Horizontal", false, false);
                    }
                    else if ((aheadPoint.position - transform.position).x < 0)
                    {
                        PlayAnimation("Horizontal", true, false);
                    }
                }
                else if (Vector3.Angle(rayCastDir, pointVector) == 90)
                {
                    if (allowToTurn90)
                    {
                        AheadPoint.localPosition = transform.right * Input.GetAxisRaw("Horizontal") * 0.5f;
                        if ((aheadPoint.position - transform.position).x > 0)
                        {
                            PlayAnimation("Horizontal", false, false);
                        }
                        else if ((aheadPoint.position - transform.position).x < 0)
                        {
                            PlayAnimation("Horizontal", true, false);
                        }
                    }
                }
            }
        }
        else if (Input.GetAxisRaw("Vertical") != 0)
        {
            if (!FireRay(new Vector3(transform.position.x, transform.position.y + Input.GetAxisRaw("Vertical"), 0) - transform.position))
            {
                if (Vector3.Angle(rayCastDir, pointVector) != 90)
                {
                    AheadPoint.localPosition = transform.up * Input.GetAxisRaw("Vertical") * 0.5f;
                    if ((aheadPoint.position - transform.position).y > 0)
                    {
                        PlayAnimation("Vertical", false, true);
                    }
                    else if ((aheadPoint.position - transform.position).y < 0)
                    {
                        PlayAnimation("Vertical", false, false);
                    }
                }
                else if (Vector3.Angle(rayCastDir, pointVector) == 90)
                {
                    if (allowToTurn90)
                    {
                        AheadPoint.localPosition = transform.up * Input.GetAxisRaw("Vertical") * 0.5f;
                        if ((aheadPoint.position - transform.position).y > 0)
                        {
                            PlayAnimation("Vertical", false, true);
                        }
                        else if ((aheadPoint.position - transform.position).y < 0)
                        {
                            PlayAnimation("Vertical", false, false);
                        }
                    }
                }
            }
        }
        if (!AheadCheck())
        {
            rb.velocity = (AheadPoint.position - transform.position).normalized * moveSpeed;
        }
        else
        {
            rb.velocity = Vector3.zero;
        }
    }

    RaycastHit2D aheadRay;
    [SerializeField] private LayerMask layerMask;

    public bool AheadCheck()
    {
        aheadRay = Physics2D.Raycast(transform.position, pointVector, 0.525f, layerMask);
        if (aheadRay)
        {
            StopAnimation();
            return true;
        }
        return false;
    }

    Vector3 rayCastDir;

    public void StopAnimation()
    {
        animator.ResetTrigger("Horizontal");
        animator.ResetTrigger("Vertical");
        if (aheadPoint.localPosition.x !=0 && aheadPoint.localPosition.y == 0)
        {
            animator.SetTrigger("IdleH");
            lastAnimationTrigger = "IdleH";
        }
        else if (aheadPoint.localPosition.y != 0 && aheadPoint.localPosition.x == 0)
        {
            animator.SetTrigger("IdleV");
            lastAnimationTrigger = "IdleV";
        }
    }

    public bool FireRay(Vector3 dir)
    {
        if (Physics2D.Raycast(transform.position, dir, 0.55f, layerMask))
        {
            return true;
        }
        rayCastDir = dir;
        return false;
    }

    public void PlayAnimation(string a, bool _flipX, bool _flipY)
    {
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName(a))
        {
            animator.SetTrigger(a);
            lastAnimationTrigger = a;
        }
        spriteRenderer.flipX = _flipX;
        spriteRenderer.flipY = _flipY;
    }

    public IEnumerator TemporaryDisablePlayerMovement()
    {
        allowToMove = false;
        yield return new WaitForSeconds(0.5f);
        allowToMove = true;
    }
}

