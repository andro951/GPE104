using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ErrorTesting : MonoBehaviour
{
    public Text starShipListCount;
    void Start()
    {

    }

    void Update()
    {
        starShipListCount.text = "starShipListCount: " + GameManager.instance.starShipList.Count;
    }
}