using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class bar : Business
{   
    public static int nbOfBars;
    public static float drainMultiplier;
    
    public bar(string name, int cost) : base(name, cost)
    {
        name = "Bar";
        cost = 175;
    }

    public override void BusinessAction()
    {
        StartCoroutine(Farm());
        base.BusinessAction();
        drainMultiplier += 3f;
        nbOfBars++;
    }
    IEnumerator Farm()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            PropreArgent.argent += 50;
        }
    }
}