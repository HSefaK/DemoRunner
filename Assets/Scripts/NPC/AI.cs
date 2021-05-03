using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.AI;
using Assets.Infrastructrue;

public class AI : MonoBehaviour
{
    public NavMeshAgent agent;

    private int moveSpeedRandomizer;
    private int countDownTime = 3;
    private int countDowntoDestroy = 3;

    private Vector3 endPos;

    private bool isGameStarted;

    private void Start()
    {
        StartCoroutine(countDownTimer());
        endPos = new Vector3(-0.64f, -0.4f, 35);
    }
    private void Update()
    {
        EndPosCheckFunction();
        moveSpeedRandomizer = UnityEngine.Random.Range(8, 10);
        NpcPlayerFlyCheckFunction();

        if (isGameStarted)
        {
            agent.updateRotation = false;
            agent.destination = endPos;
            agent.speed = moveSpeedRandomizer;
            agent.autoBraking = false;

            if (agent.transform.position.z < GameConstant.GAME_END_POSITION_NPC)
            {
                agent.GetComponent<Animator>().Play(GameConstant.RUNNING);
            }
            else if (agent.transform.position.z > GameConstant.GAME_END_POSITION_NPC)
            {
                agent.GetComponent<Animator>().Play(GameConstant.DANCE);
                agent.speed = 0;
                StartCoroutine(countDownDestroy());
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
    IEnumerator countDownDestroy()
    {
        while (countDowntoDestroy > 0)
        {
            yield return new WaitForSeconds(1f);
            countDowntoDestroy--;
        }
        agent.gameObject.SetActive(false);
        yield return new WaitForSeconds(1f);
    }
    void EndPosCheckFunction()
    {
        if (agent.transform.position.z > GameConstant.GAME_END_POSITION_AGENT)
        {
            agent.acceleration = 0;
            agent.speed = 0;
            agent.velocity = Vector3.zero;
        }
    }
    void NpcPlayerFlyCheckFunction()
    {
        Vector3 npcPlayerRespawn;
        {
            agent.speed = 0;
            if (agent.transform.position.y < -GameConstant.PLAYER_FLY_Y_AXIS)
            {
                npcPlayerRespawn = new Vector3(6.62f, -7.82f, -4f);
                agent.Warp(npcPlayerRespawn);
                agent.speed = moveSpeedRandomizer;
            }
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        Vector3 playerHarder = new Vector3(agent.transform.position.x, agent.transform.position.y, agent.transform.position.z);
        float harderDegree = Time.deltaTime * 10;
        float finalPos = 0f;
        bool collisionDetection = false;
        if (collision.gameObject.CompareTag(GameConstant.OBSTACLE_TURNING_RIGHT_TO_LEFT))
        {
            finalPos = agent.transform.position.x + harderDegree;
            collisionDetection = true;
        }

        if (collision.gameObject.CompareTag(GameConstant.OBSTACLE_TURNING_LEFT_TO_RIGHT))
        {
            finalPos = agent.transform.position.x - harderDegree;
            collisionDetection = true;
        }
        if (collisionDetection)
        {
            playerHarder = new Vector3(finalPos, agent.transform.position.y, agent.transform.position.z);
            agent.Warp(playerHarder);
        }

    }
    private void OnCollisionEnter(Collision collision)
    {

        Vector3 npcPlayerRespawn;
        if (collision.gameObject.CompareTag(GameConstant.ENEMY))
        {
            npcPlayerRespawn = new Vector3(0.25f, 0.043f, -65f);
            agent.Warp(npcPlayerRespawn);
        }

        if (collision.gameObject.CompareTag(GameConstant.SPEED_DOWNER_STICKS))
        {
            agent.speed = moveSpeedRandomizer / 2;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        Vector3 playerHarder;
        if (collision.gameObject.CompareTag(GameConstant.SPEED_DOWNER_STICKS))
        {
            agent.speed = moveSpeedRandomizer;
        }

        if (collision.gameObject.CompareTag(GameConstant.OBSTACLE_TURNING_RIGHT_TO_LEFT))
        {
            playerHarder = new Vector3(agent.transform.position.x, agent.transform.position.y, agent.transform.position.z);
            agent.transform.position = playerHarder;
        }

        if (collision.gameObject.CompareTag(GameConstant.OBSTACLE_TURNING_LEFT_TO_RIGHT))
        {
            playerHarder = new Vector3(agent.transform.position.x, agent.transform.position.y, agent.transform.position.z);
            agent.transform.position = playerHarder;
        }
    }
}
