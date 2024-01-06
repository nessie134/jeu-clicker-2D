using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoLeaf : MonoBehaviour
{
    //public static int nbEmployees;
    private void Start()
    {
        StartCoroutine(CreateTheCookie());
    }
    IEnumerator CreateTheCookie()
    {
        while (true)
        {
            GlobalLeaves.leafCount += GlobalEmployee.nbOfEmployees;
            yield return new WaitForSeconds(1);
        }
    }
}
