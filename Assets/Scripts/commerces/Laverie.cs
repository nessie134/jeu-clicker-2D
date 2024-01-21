using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

public class Laverie : Business
{

    public static float drainMultiplier;
    public static int nbOfLaveries
    {
        get => nbOfLaveries;
        set => nbOfLaveries = value;
    }


    public Laverie(string name, int cost) : base(name, cost)
    {
        name = "Laverie";
        cost = 200;
    }

    public override void BusinessAction()
    {
        drainMultiplier = 1.5f;
        nbOfLaveries += 1;

    }
}

