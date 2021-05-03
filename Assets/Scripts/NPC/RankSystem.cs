using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using Assets.Infrastructrue;

public class RankSystem : MonoBehaviour
{
    public Text positionDiplay;

    private GameObject player;
    private GameObject []NPCs;

    private float[] positionArray = new float[11];

    void Start()
    {
        NPCs = GameObject.FindGameObjectsWithTag(GameConstant.NPC);
        player = GameObject.Find(GameConstant.BOY);

    }

    void Update()
    { 
        if (player.transform.position.z < 32) {
            FillPositionArrayFunction();
            PositionFoundDisplayerFunction();
        }
    }

    void FillPositionArrayFunction()
    {

        for (int i = 0; i < NPCs.Length; i++)
        {
            positionArray[i] = NPCs[i].GetComponent<Transform>().position.z; 
        }
        positionArray[10] = player.transform.position.z;
       
    }

    void PositionFoundDisplayerFunction()
    {
        positionArray = positionArray.OrderByDescending(c => c).ToArray();
        System.Array.IndexOf(positionArray, player.transform.position.z);
        positionDiplay.GetComponent<Text>().text = (System.Array.IndexOf(positionArray, player.transform.position.z) + 1).ToString() + "/11";
    }

}
