using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteControlPlayer : MonoBehaviour
{
    public enum PlayerControlMode
    {
        One,
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        UD,
        LR,
    };

    public PlayerControlMode mode;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            switch (mode)
            {
                case PlayerControlMode.One:
                    collision.GetComponent<PlayerMovement>().SetAllow(false, true, false, true);
                    collision.GetComponent<PlayerMovement>().StopMove();
                    break;
                case PlayerControlMode.Two:
                    collision.GetComponent<PlayerMovement>().SetAllow(true, true, false, true);
                    collision.GetComponent<PlayerMovement>().StopMove();

                    break;
                case PlayerControlMode.Three:
                    collision.GetComponent<PlayerMovement>().SetAllow(true, false, false, true);
                    collision.GetComponent<PlayerMovement>().StopMove();

                    break;
                case PlayerControlMode.Four:
                    collision.GetComponent<PlayerMovement>().SetAllow(false, true, true, true);
                    collision.GetComponent<PlayerMovement>().StopMove();

                    break;
                case PlayerControlMode.Five:
                    collision.GetComponent<PlayerMovement>().SetAllow(true, true, true, true);
                    collision.GetComponent<PlayerMovement>().StopMove();

                    break;
                case PlayerControlMode.Six:
                    collision.GetComponent<PlayerMovement>().SetAllow(true, false, true, true);
                    collision.GetComponent<PlayerMovement>().StopMove();

                    break;
                case PlayerControlMode.Seven:
                    collision.GetComponent<PlayerMovement>().SetAllow(false, true, true, false);
                    collision.GetComponent<PlayerMovement>().StopMove();

                    break;
                case PlayerControlMode.Eight:
                    collision.GetComponent<PlayerMovement>().SetAllow(true, true, true, false);
                    collision.GetComponent<PlayerMovement>().StopMove();

                    break;
                case PlayerControlMode.Nine:    
                    collision.GetComponent<PlayerMovement>().SetAllow(true, false, true, false);
                    collision.GetComponent<PlayerMovement>().StopMove();

                    break;
                case PlayerControlMode.UD:
                    collision.GetComponent<PlayerMovement>().SetAllow(false, false, true, true);
                    collision.GetComponent<PlayerMovement>().DisableBox();

                    break;
                case PlayerControlMode.LR:
                    collision.GetComponent<PlayerMovement>().SetAllow(true, true, false, false);
                    collision.GetComponent<PlayerMovement>().DisableBox();

                    break;

                default:
                    break;
            }
        }
    }
}
