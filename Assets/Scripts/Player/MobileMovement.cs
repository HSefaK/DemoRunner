using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class MobileMovement : MonoBehaviour
{
    //private Touch touch;
    //private int countDownTime = 3;
    //private int harderCounter = 0;
    //private float horizontalSpeedMultiplier = 0.35f;
    //private float moveSpeed = 6f;

    //private GameObject player;

    //public Text countDownDisplay;


    //private void Start()
    //{
    //    player = GameObject.Find("Boy");
    //}

    //private void Update()
    //{
    //    PlayerMovement();
    //    StartCoroutine(countDownTimer());
    //}

    //private void PlayerMovement()
    //{
    //    if (countDownTime == 0)
    //    {
    //        if (Input.touchCount > 0)
    //        {
    //            touch = Input.GetTouch(0);

    //            if (touch.phase == TouchPhase.Moved)
    //            {
    //                transform.position = new Vector3(
    //                    transform.position.x + touch.deltaPosition.x * Time.deltaTime * horizontalSpeedMultiplier,
    //                    transform.position.y,
    //                    transform.position.z + moveSpeed);
    //            }
    //        }
    //    }

    //    Vector3 playerMove = new Vector3(0, 0, 1) * moveSpeed * Time.deltaTime;
    //    transform.Translate(playerMove, Space.Self);

    //}


    //IEnumerator countDownTimer()
    //{
    //    while (countDownTime > 0)
    //    {
    //        moveSpeed = 0f;
    //        countDownDisplay.text = countDownTime.ToString();

    //        yield return new WaitForSeconds(1f);

    //        countDownTime--;
    //    }

    //    countDownDisplay.text = "GO!";

    //    moveSpeed = 6f;

    //    yield return new WaitForSeconds(1f);

    //    countDownDisplay.gameObject.SetActive(false);
    //}

    //private void OnCollisionStay(Collision collision)
    //{
    //    Vector3 playerHarder = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
    //    float harderDegree = Time.deltaTime * 10;


    //    if (collision.gameObject.CompareTag("RtoL"))
    //    {
    //        harderCounter--;
    //        playerHarder = new Vector3(player.transform.position.x + harderDegree, player.transform.position.y, player.transform.position.z);
    //        player.transform.position = playerHarder;

    //    }

    //    if (collision.gameObject.CompareTag("LtoR"))
    //    {
    //        harderCounter++;
    //        playerHarder = new Vector3(player.transform.position.x - harderDegree, player.transform.position.y, player.transform.position.z);
    //        player.transform.position = playerHarder;
    //    }


    //}

    //private void OnCollisionEnter(Collision collision)
    //{

    //    Vector3 playerRespawn = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
    //    if (collision.gameObject.CompareTag("Enemy"))
    //    {
    //        playerRespawn = new Vector3(0.25f, 0.043f, -65f);
    //        player.transform.position = playerRespawn;
    //        moveSpeed = 6f;

    //    }

    //    if (collision.gameObject.CompareTag("SpeedDowner"))
    //    {
    //        moveSpeed = 3f;
    //    }


    //}

    //private void OnCollisionExit(Collision collision)
    //{

    //    Vector3 playerHarder = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
    //    if (collision.gameObject.CompareTag("SpeedDowner"))
    //    {
    //        moveSpeed = 6f;
    //    }


    //    if (collision.gameObject.CompareTag("RtoL"))
    //    {

    //        playerHarder = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
    //        player.transform.position = playerHarder;
    //    }

    //    if (collision.gameObject.CompareTag("LtoR"))
    //    {

    //        playerHarder = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
    //        player.transform.position = playerHarder;
    //    }

    //    if (collision.gameObject.CompareTag("Rotator"))
    //    {
    //        playerHarder = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
    //        player.transform.position = playerHarder;
    //        harderCounter = 0;
    //    }
    //}

}
