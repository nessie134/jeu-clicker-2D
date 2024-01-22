using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class fastfood : Business
{   
    public static int nbOfFf;
    public static float drainMultiplier;
    
    public fastfood(string name, int cost) : base(name, cost)
    {
        name = "Fast Food";
        cost = 1000;
    }

    public override void BusinessAction()
    {
        base.BusinessAction();
        drainMultiplier = 3f;
        nbOfFf++;
    }
}