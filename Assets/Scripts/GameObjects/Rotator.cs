using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Infrastructrue;

public class Rotator : MonoBehaviour
{
    private GameObject[] rotatingSticks;

    private GameObject rotatingStick6;
    private GameObject rotatingStick7;
    private GameObject screwerLtoR;
    private GameObject rotatorRoad;
    private GameObject rotatingRoad;
    private GameObject rotatingRoad2;
    private GameObject rotatingRoad3;
    private GameObject movingStick;

    private int rotationSpeed = 100;
    private int rotationRandomizer;

    private float movingSpeed = 1f;

    private bool isStickRighted = false;
    private bool isStickLefted = true;
    private bool isHorizontalObstacleLtoRRighted = false;
    private bool isHorizontalObstacleLtoRLefted = true;

    void Start()
    {
        FindMethod();
    }

    void Update()
    {
        RoadRotatorFunction();
        StickRotator();
        StickMoverFunction();
        HorizontalObstacleLtoRMoverFunction();
        rotationRandomizer = Random.Range(1, 5);
    }

    void FindMethod()
    {
        rotatingSticks = GameObject.FindGameObjectsWithTag(GameConstant.SPEED_DOWNER_STICKS);
        movingStick = GameObject.Find("MovingStick");
        rotatingRoad = GameObject.Find("RotatingRoad");
        rotatingRoad2 = GameObject.Find("RotatingRoad2");
        rotatingRoad3 = GameObject.Find("RotatingRoad3");
        rotatorRoad = GameObject.Find("Rotator");
        screwerLtoR = GameObject.Find("HorizontalObstacleLtoR");
        rotatingStick6 = GameObject.Find("RotatingStick6");
        rotatingStick7 = GameObject.Find("RotatingStick7");
    }
    void RoadRotatorFunction()
    {
        rotatingRoad.transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
        rotatingRoad2.transform.Rotate(0, 0, -rotationSpeed * Time.deltaTime);
        rotatingRoad3.transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }
    void StickRotator()
    {
        rotatorRoad.transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
        rotatingStick6.transform.RotateAround(rotatingStick7.transform.position, Vector3.up, rotationSpeed * Time.deltaTime);
        rotatingStick7.transform.Rotate(0, 0, -rotationSpeed * Time.deltaTime);
        for (int i = 0; i < rotatingSticks.Length; i++)
        {
            rotatingSticks[i].GetComponent<Transform>().Rotate(0, 0, -rotationSpeed * Time.deltaTime);
        }
    }
    void HorizontalObstacleLtoRMoverFunction()
    {
        Vector3 HorizontalObstacleLtoRVector = screwerLtoR.transform.position;
        screwerLtoR.transform.Rotate(0, rotationSpeed * Time.deltaTime * 10, 0);
        if (isHorizontalObstacleLtoRLefted && !isHorizontalObstacleLtoRRighted)
        {
            HorizontalObstacleLtoRVector.x += movingSpeed * Time.deltaTime * 3;
            HorizontalObstacleLtoRVector.z += movingSpeed * Time.deltaTime * rotationRandomizer;
            screwerLtoR.transform.position = HorizontalObstacleLtoRVector;
            if (HorizontalObstacleLtoRVector.x > 2.2)
            {
                isHorizontalObstacleLtoRLefted = false;
                isHorizontalObstacleLtoRRighted = true;
            }
        }
        else if (!isHorizontalObstacleLtoRLefted && isHorizontalObstacleLtoRRighted)
        {
            HorizontalObstacleLtoRVector.x -= movingSpeed * Time.deltaTime * 3;
            HorizontalObstacleLtoRVector.z -= movingSpeed * Time.deltaTime * rotationRandomizer;
            screwerLtoR.transform.position = HorizontalObstacleLtoRVector;
            if (HorizontalObstacleLtoRVector.x < -2.2)
            {
                isHorizontalObstacleLtoRRighted = false;
                isHorizontalObstacleLtoRLefted = true;
            }
        }
    }

    void StickMoverFunction()
    {
        Vector3 stickVector = movingStick.transform.position;
        if (isStickLefted && !isStickRighted)
        {
            stickVector.x += movingSpeed * Time.deltaTime * 5;
            movingStick.transform.position = stickVector;
            if (stickVector.x > 3.9)
            {
                isStickLefted = false;
                isStickRighted = true;
            }
        }
        else if (!isStickLefted && isStickRighted)
        {
            stickVector.x -= movingSpeed * Time.deltaTime;
            movingStick.transform.position = stickVector;
            if (stickVector.x < 0.75)
            {
                isStickRighted = false;
                isStickLefted = true;
            }
        }

    }
}
