using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using Assets.Infrastructrue;

public class SwervingMech : MonoBehaviour
{
    public Text countDownDisplay;
    public float moveSpeed = 6f;

    private GameObject player;
    private int countDownTime = 3;

    void Start()
    {
        player = GameObject.Find(GameConstant.BOY);
        StartCoroutine(countDownTimer());
    }

    void Update()
    {
        PlayerFlyCheckFunction();
        MouseMoveFunction();
    }

    IEnumerator countDownTimer()
    {
        while (countDownTime > 0)
        {
            moveSpeed = 0f;
            countDownDisplay.text = countDownTime.ToString();
            yield return new WaitForSeconds(1f);
            countDownTime--;
        }
        countDownDisplay.text = "GO!";
        moveSpeed = 6f;
        yield return new WaitForSeconds(1f);
        countDownDisplay.gameObject.SetActive(false);
    }


    void MouseMoveFunction()
    {

        if (countDownTime == 0)
        {


            if (Input.mousePosition.y > 180 || Input.mousePosition.y < 90)
            {
                if (player.transform.position.z < 35)
                {
                    Vector3 mouse = Camera.main.ScreenToViewportPoint(Input.mousePosition);
                    player.transform.position = new Vector3(mouse.x * 10 - 5, player.transform.position.y, player.transform.position.z + Time.deltaTime * 6);



                }
            }
        }

    }
    void PlayerFlyCheckFunction()
    {
        Vector3 playerRespawn = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
        if (player.transform.position.y < -1)
        {
            moveSpeed = 0;
            if (player.transform.position.y < -15)
            {
                playerRespawn = new Vector3(0.25f, 0.043f, -65f);
                player.transform.position = playerRespawn;
                moveSpeed = 6f;
            }
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        Vector3 playerHarder = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
        float harderDegree = Time.deltaTime * 10;
        float finalPos = 0f;
        bool collisionDetection = false;
        if (collision.gameObject.CompareTag(GameConstant.OBSTACLE_TURNING_RIGHT_TO_LEFT))
        {
            finalPos = player.transform.position.x + harderDegree;
            collisionDetection = true;
        }

        if (collision.gameObject.CompareTag(GameConstant.OBSTACLE_TURNING_LEFT_TO_RIGHT))
        {
            finalPos = player.transform.position.x - harderDegree;
            collisionDetection = true;
        }
        if (collisionDetection)
        {
            playerHarder = new Vector3(finalPos, player.transform.position.y, player.transform.position.z);
            player.transform.position = playerHarder;
        }

    }
    private void OnCollisionEnter(Collision collision)
    {

        Vector3 playerRespawn = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
        if (collision.gameObject.CompareTag(GameConstant.ENEMY))
        {
            playerRespawn = new Vector3(0.25f, 0.043f, -65f);
            player.transform.position = playerRespawn;
            moveSpeed = 6f;
        }

        if (collision.gameObject.CompareTag(GameConstant.SPEED_DOWNER_STICKS))
        {
            moveSpeed = 6f;
        }

    }

    private void OnCollisionExit(Collision collision)
    {
        Vector3 playerHarder = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
        if (collision.gameObject.CompareTag(GameConstant.SPEED_DOWNER_STICKS))
        {
            moveSpeed = 6f;
        }

        if (collision.gameObject.CompareTag(GameConstant.OBSTACLE_TURNING_RIGHT_TO_LEFT))
        {
            playerHarder = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
            player.transform.position = playerHarder;
        }

        if (collision.gameObject.CompareTag(GameConstant.OBSTACLE_TURNING_LEFT_TO_RIGHT))
        {
            playerHarder = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
            player.transform.position = playerHarder;
        }

        if (collision.gameObject.CompareTag("Rotator"))
        {
            playerHarder = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
            player.transform.position = playerHarder;
        }
    }
}
