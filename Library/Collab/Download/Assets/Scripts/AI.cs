using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.AI;

public class AI : MonoBehaviour
{
    public NavMeshAgent agent;
    public Camera cam;
    private int harderCounterNPC= 0;
    private float npcMoveSpeed = 6f;
    private GameObject npcPlayer;
    private int moveSpeedRandomizer;
    private Vector3 endPos;
    private Vector3 rotatePos;
    private int countDownTime = 3;
    private bool isGameStarted;
 
    private void Start()
    {

        StartCoroutine(countDownTimer());
        endPos = new Vector3(600, 200,0);
        rotatePos = new Vector3(0, 0, 0);

    }
    private void Update()
    {
        endPosCheckFunction();
        //if (agent.velocity.sqrMagnitude > Mathf.Epsilon)
        //{
        //    transform.rotation = Quaternion.LookRotation(agent.velocity.normalized);
        //}
        moveSpeedRandomizer = UnityEngine.Random.Range(3, 7);
        npcPlayerFlyCheckFunction();



        if (isGameStarted== true)
        {
            
            agent.GetComponent<Animator>().Play("Running");
            Ray ray = cam.ScreenPointToRay(endPos);
            agent.updateRotation = false;
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                agent.speed = moveSpeedRandomizer;
                agent.SetDestination(hit.point);
            }
            else if (agent.transform.position.z > 95)
            {
                agent.GetComponent<Animator>().Play("Dance");
                agent.speed = 0;
            }


        }
    }

    IEnumerator countDownTimer()
    {
        while (countDownTime > 0)
        {
            isGameStarted = false;

            yield return new WaitForSeconds(1f);

            countDownTime--;
        }

        isGameStarted = true;

        yield return new WaitForSeconds(1f);


    }
    void endPosCheckFunction()
    {
        if (agent.transform.position.z > 95)
        {
            agent.acceleration = 0;
            agent.speed = 0;
            agent.velocity = Vector3.zero;

        }
    }
    void npcPlayerFlyCheckFunction()
    {
        //Vector3 playerGroundStabilizier = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
        Vector3 npcPlayerRespawn = new Vector3(agent.transform.position.x, agent.transform.position.y, agent.transform.position.z);
        if (agent.transform.position.y < -1)
        {
            npcMoveSpeed = 0;
            if (agent.transform.position.y < -15)
            {
                npcPlayerRespawn = new Vector3(6.62f, -7.82f, -4f);
                agent.Warp(npcPlayerRespawn);
                npcMoveSpeed = moveSpeedRandomizer;
                harderCounterNPC = 0;

            }


        }
    }
    private void OnCollisionStay(Collision collision)
    {
        Vector3 playerHarder = new Vector3(agent.transform.position.x, agent.transform.position.y, agent.transform.position.z);
        float harderDegree = Time.deltaTime * 10;


        if (collision.gameObject.CompareTag("RtoL"))
        {
            harderCounterNPC--;
            playerHarder = new Vector3(agent.transform.position.x + harderDegree, agent.transform.position.y, agent.transform.position.z);
            agent.Warp(playerHarder);
        }

        if (collision.gameObject.CompareTag("LtoR"))
        {
            harderCounterNPC++;
            playerHarder = new Vector3(agent.transform.position.x - harderDegree, agent.transform.position.y, agent.transform.position.z);
            agent.Warp(playerHarder);
            
        }


    }
    private void OnCollisionEnter(Collision collision)
    {

        Vector3 npcPlayerRespawn = new Vector3(agent.transform.position.x, agent.transform.position.y, agent.transform.position.z);
        if (collision.gameObject.CompareTag("Enemy"))
        {
            //Not working why?   
            npcPlayerRespawn = new Vector3(0.25f, 0.043f, -65f);
            agent.Warp (npcPlayerRespawn);
            
            //npcMoveSpeed = moveSpeedRandomizer;
            //Debug.Log(agent.transform.position);

        }

        if (collision.gameObject.CompareTag("SpeedDowner"))
        {
            npcMoveSpeed = moveSpeedRandomizer/2;
        }


        //if (collision.gameObject.CompareTag("Jumper"))
        //{
        //    playerRespawn = new Vector3(player.transform.position.x, player.transform.position.y + 25 , player.transform.position.z);
        //}
    }

    private void OnCollisionExit(Collision collision)
    {

        Vector3 playerHarder = new Vector3(agent.transform.position.x, agent.transform.position.y, agent.transform.position.z);
        if (collision.gameObject.CompareTag("SpeedDowner"))
        {
            npcMoveSpeed = moveSpeedRandomizer;
        }


        if (collision.gameObject.CompareTag("RtoL"))
        {

            playerHarder = new Vector3(agent.transform.position.x, agent.transform.position.y, agent.transform.position.z);
            agent.transform.position = playerHarder;
            //harderCounter = 0;
        }

        if (collision.gameObject.CompareTag("LtoR"))
        {

            playerHarder = new Vector3(agent.transform.position.x, agent.transform.position.y, agent.transform.position.z);
            agent.transform.position = playerHarder;
            //harderCounter = 0;
        }
    }














}
