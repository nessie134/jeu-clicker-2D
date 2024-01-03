using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MakeCookies : MonoBehaviour
{
    public int nbClicks = 1;

    public void ClickTheButton()
    {
        GlobalCookies.cookieCount += nbClicks;
        Debug.Log(GlobalCookies.cookieCount);
    }
}
