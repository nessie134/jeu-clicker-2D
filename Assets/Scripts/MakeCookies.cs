using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MakeCookies : MonoBehaviour
{
    //public GameObject textBox;

    public void ClickTheButton()
    {
        GlobalCookies.cookieCount += 1;
        Debug.Log(GlobalCookies.cookieCount);
    }
}
