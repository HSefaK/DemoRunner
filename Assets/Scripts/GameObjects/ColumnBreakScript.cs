using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Infrastructrue;

public class ColumnBreakScript : MonoBehaviour
{
    public GameObject unbrokenColumn;
    public GameObject brokenColumn;

    private bool isWallBroken = false;

    void Start()
    {
        unbrokenColumn.SetActive(true);
        brokenColumn.SetActive(false);
    }

    void BreakColumn()
    {
        if (isWallBroken == false)
        {
            unbrokenColumn.SetActive(false);
            brokenColumn.SetActive(false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag(GameConstant.NPC))
        {
            BreakColumn();
            isWallBroken = true;
            Destroy(unbrokenColumn.gameObject);
            Destroy(brokenColumn.gameObject);
        }
    }

}