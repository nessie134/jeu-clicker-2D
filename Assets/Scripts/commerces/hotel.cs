using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class hotel : Business
{   
    public static int nbOfHotel;
    public static float drainMultiplier;
    
    public hotel(string name, int cost) : base(name, cost)
    {
        name = "Hotel";
        cost = 10000;
    }

    public override void BusinessAction()
    {
        base.BusinessAction();
        drainMultiplier = 4f;
        nbOfHotel++;
        StartCoroutine(Farm());
    }
    IEnumerator Farm()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            PropreArgent.argent += 5000;
        }
    }
}