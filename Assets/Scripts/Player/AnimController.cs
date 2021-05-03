using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Infrastructrue;


public class AnimController : MonoBehaviour
{
    public GameObject wall;

    private GameObject Player;
    private SwervingMech speed;
    private int countDownTime = 3;
    private static bool isInputEnabled = true;

    Animator animController;
    private void Start()
    {
        speed = GetComponent<SwervingMech>();
        Player = GameObject.Find(GameConstant.BOY);
        animController = GetComponent<Animator>();
    }

    void Update()
    {
        CharAnimControllerFunction();
    }
    IEnumerator danceCountDown()
    {
        while (countDownTime > 0)
        {
            speed.moveSpeed = 0f;
            yield return new WaitForSeconds(1f);
            countDownTime--;
        }
        Player.GetComponent<Animator>().Play(GameConstant.STANDING);
    }
    void CharAnimControllerFunction()
    {
        string moveAnimation = "";
        if (isInputEnabled && Player.transform.position.z < GameConstant.GAME_END_POSITION_PLAYER && Player.transform.position.y > -1)
        {
            if ((Player.transform.position.z < GameConstant.ROTATOR_START_AXIS || Player.transform.position.z > GameConstant.ROTATOR_FINISH_AXIS) && (Input.mousePosition.y > 180 || Input.mousePosition.y < 90))
            {
                moveAnimation = GameConstant.RUNNING;
            }
            else if (Input.mousePosition.y > 180 || Input.mousePosition.y < 90)
            {
                moveAnimation = GameConstant.RUNNING_WITHOUT_BALANCE;
            }
            else
            {
                moveAnimation = GameConstant.STANDING;
            }
        }

        else
        {
            if (Player.transform.position.y > -1)
            {
                isInputEnabled = true;
            }
            if (Player.transform.position.y < -2)
            {
                moveAnimation = GameConstant.FLYING;
            }
            else if (Player.transform.position.z > GameConstant.GAME_END_POSITION_PLAYER && countDownTime >= 0)
            {
                moveAnimation = GameConstant.DANCE;
                StartCoroutine(danceCountDown());
            }
            else if (countDownTime <= 0)
            {
                moveAnimation = GameConstant.STANDING;
                wall.SetActive(true);
            }
        }
        Player.GetComponent<Animator>().Play(moveAnimation);
    }
}
