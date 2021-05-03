using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwervingMech : MonoBehaviour
{


    private Rigidbody rb;
    private float dirX, dirZ;
    private GameObject player;
    private int countDownTime = 3;
    public Text countDownDisplay;

    private int harderCounter = 0;

    public float moveSpeed ;

    void Start()
    {
        player = GameObject.Find("Boy");
        rb = GetComponent<Rigidbody>();
        StartCoroutine(countDownTimer());
    }

    void Update()
    {
        dirX = Input.GetAxis("Horizontal") * moveSpeed;
        dirZ = Input.GetAxis("Vertical") * moveSpeed;
        playerFlyCheckFunction();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector3(dirX, rb.velocity.y, dirZ);

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

    void playerFlyCheckFunction()
    {
        //Vector3 playerGroundStabilizier = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
        Vector3 playerRespawn = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
        if (player.transform.position.y < -1)
        {
            moveSpeed = 0;
            if (player.transform.position.y < -15)
            {
                playerRespawn = new Vector3(0.25f, 0.043f, -65f);
                player.transform.position = playerRespawn;
                moveSpeed = 6f;
                harderCounter = 0;

            }


        }
    }

    private void OnCollisionStay(Collision collision)
    {
        Vector3 playerHarder = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
        float harderDegree = Time.deltaTime * 10;


        if (collision.gameObject.CompareTag("RtoL"))
        {
            harderCounter--;
            playerHarder = new Vector3(player.transform.position.x + harderDegree, player.transform.position.y, player.transform.position.z);
            player.transform.position = playerHarder;
        }

        if (collision.gameObject.CompareTag("LtoR"))
        {
            harderCounter++;
            playerHarder = new Vector3(player.transform.position.x - harderDegree, player.transform.position.y, player.transform.position.z);
            player.transform.position = playerHarder;
        }

        if (collision.gameObject.CompareTag("Rotator"))
        {
            harderCounter++;
            playerHarder = new Vector3(player.transform.position.x - harderDegree, player.transform.position.y, player.transform.position.z);
            player.transform.position = playerHarder;
        }


    }
    private void OnCollisionEnter(Collision collision)
    {
        
        Vector3 playerRespawn = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
        if (collision.gameObject.CompareTag("Enemy"))
        {
            playerRespawn = new Vector3(0.25f, 0.043f, -65f);
            player.transform.position = playerRespawn;
            moveSpeed = 6f;
            
        }

        if (collision.gameObject.CompareTag("SpeedDowner"))
        {
            moveSpeed = 3f;
        }
       

        //if (collision.gameObject.CompareTag("Jumper"))
        //{
        //    playerRespawn = new Vector3(player.transform.position.x, player.transform.position.y + 25 , player.transform.position.z);
        //}
    }

    private void OnCollisionExit(Collision collision)
    {

        Vector3 playerHarder = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
        if (collision.gameObject.CompareTag("SpeedDowner"))
        {
            moveSpeed = 6f;
        }


        if (collision.gameObject.CompareTag("RtoL"))
        {

            playerHarder = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
            player.transform.position = playerHarder;
            //harderCounter = 0;
        }

        if (collision.gameObject.CompareTag("LtoR"))
        {

            playerHarder = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
            player.transform.position = playerHarder;
            //harderCounter = 0;
        }

        if (collision.gameObject.CompareTag("Rotator"))
        {
            playerHarder = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
            player.transform.position = playerHarder;
            harderCounter = 0;
        }
    }


}
