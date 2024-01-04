using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GlobalCookies : MonoBehaviour
{
    public static int cookieCount;
    private TextMeshProUGUI _argent;

    private void Start()
    {
        _argent = gameObject.GetComponentInChildren<TextMeshProUGUI>();
    }

    public void Update()
    {
        _argent.text = "Argent " + cookieCount + "$";
    }

    public void saveCookie()
    {
        PlayerPrefs.SetInt("nbCookies", cookieCount);
        PlayerPrefs.Save();
    }
}
