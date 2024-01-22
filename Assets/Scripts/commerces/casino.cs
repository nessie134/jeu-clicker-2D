using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class casino : Business
{   
    public static int nbOfCas;
    public static float drainMultiplier;
    
    
    public casino(string name, int cost) : base(name, cost)
    {
        name = "Casino";
        cost = 50000;
    }

    public override void BusinessAction()
    {
        base.BusinessAction();
        drainMultiplier = 5f;
        nbOfCas++;
    }
}