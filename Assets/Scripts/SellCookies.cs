using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SellCookies : MonoBehaviour
{
    //public GameObject textBox;

    public void ClickTheButton()
    {
        if (GlobalLeaves.leafCount == 0)
        { //si le nombre de cookie est égal à 0
            Debug.Log("You don't have anything to sell!");
        }
        else
        {
            GlobalLeaves.leafCount -= 1; //va affichr le nombre dans global cookies
            Debug.Log(GlobalLeaves.leafCount);
        }

    }
}
