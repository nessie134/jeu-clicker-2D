using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GlobalEmployee : MonoBehaviour
{
    public GameObject fakeButton;
    public GameObject fakeText;
    public GameObject realButton;
    public GameObject realText;

    public static int employeeValue = 10;
    public static bool turnOffButton = false;

    public int currentLeaves;

    // Update is called once per frame
    void Update()
    {
        currentLeaves = GlobalCookies.cookieCount;
        fakeButton.GetComponentInChildren<Text>().text = "Buy Employee - $ " + employeeValue;
        realButton.GetComponentInChildren<Text>().text = "Buy Employee - $ " + employeeValue;

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
