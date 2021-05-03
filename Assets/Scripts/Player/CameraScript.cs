using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform player;
    private Vector3 offset = new Vector3(0, 5, -4);
    private Vector3 temp;

    void Update()
    {
        transform.position = player.position + offset;
        PlayerPosControlFunction();  
    }

    void PlayerPosControlFunction()
    {
        float cameraSmoother = Time.deltaTime * 3;

        if (player.position.z > 35)
        {
            offset = new Vector3(0f, offset.y - cameraSmoother, offset.z + cameraSmoother);
            if (offset.z > -1)
            {
                offset = new Vector3(0f, 4.75f, 0f);
            }
        }
        else
        {
            temp = transform.position;
            temp = new Vector3(-0.3f, 4.75f, player.position.z+offset.z);
            transform.position = temp;
        }
    }
}
