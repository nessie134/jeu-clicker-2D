using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class Laverie : Business
{   
    public static int nbOfLaveries;
    public static float drainMultiplier;
    
    public Laverie(string name, int cost) : base(name, cost)
    {
        name = "Laverie";
        cost = 50;
    }

    public override void BusinessAction()
    {
        base.BusinessAction();
        suspiscionBar.drainMultiplier += 2f;
        nbOfLaveries++;
        StartCoroutine(Farm());
    }
    IEnumerator Farm()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            PropreArgent.argent += 5;
        }
    }
}


