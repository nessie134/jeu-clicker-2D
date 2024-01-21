using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

public class Laverie : Business
{
    public static float drainMultiplier;
    public static int nbOfLaveries;


    public Laverie(string name, int cost) : base(name, cost)
    {
        name = "Laverie";
        cost = 200;
    }

    public override void BusinessAction()
    {
        suspiscionBar.drainMultiplier = 4f;
        nbOfLaveries += 1;

    }
}

