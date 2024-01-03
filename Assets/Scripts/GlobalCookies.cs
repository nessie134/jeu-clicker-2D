using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GlobalCookies : MonoBehaviour
{
    public static int cookieCount;
    private int internalCookies;
    private TextMeshProUGUI _argent;

    private void Start()
    {
        _argent = gameObject.GetComponentInChildren<TextMeshProUGUI>();
    }

    public void Update()
    {
        internalCookies = cookieCount;
        _argent.text = internalCookies + "$";
    }
}
