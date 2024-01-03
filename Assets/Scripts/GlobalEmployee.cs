using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class GlobalEmployee : MonoBehaviour
{   
    [SerializeField] private GameObject fakeButton;
    [SerializeField] private GameObject realButton;
    private TextMeshProUGUI realText;
    private TextMeshProUGUI fakeText;

    public static int employeeValue = 10;
    public static bool turnOffButton = false;

    public int currentLeaves;

    private void Start()
    {
        realText = realButton.GetComponentInChildren<TextMeshProUGUI>();
        fakeText = fakeButton.GetComponentInChildren<TextMeshProUGUI>();
    }

    void Update()
    {
        currentLeaves = GlobalCookies.cookieCount;
        realText.text = "Acheter " + employeeValue + "$";
        fakeText.text = "Acheter " + employeeValue + "$";

        if (currentLeaves >= employeeValue)
        {
            fakeButton.SetActive(false);
            realButton.SetActive(true);
        }
        if (turnOffButton == true)//Si le bouton est eteint
        {
            fakeButton.SetActive(true) ;//on allume notre bouton fake qui montre que le bouton est désactivé
            realButton.SetActive(false);//on désac le vrai pour pas qu'on puisse appuyer dessus
            turnOffButton = false;
        }
    }
}
