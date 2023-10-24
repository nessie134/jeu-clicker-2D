using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalCookies : MonoBehaviour
{
    public static int cookieCount;
    public GameObject cookieDisplay;
    public int internalCookies;


    public void Update()
    {
        internalCookies = cookieCount;
        cookieDisplay.GetComponent<Text>().text = "Cookies : " + internalCookies;
    }
}
