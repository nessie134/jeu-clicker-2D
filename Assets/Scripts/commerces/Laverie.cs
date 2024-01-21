using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

public class Laverie : Business
{
    private suspicionBar susBar;
    private float baseDrainMultiplier = 1.0f;
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
        susBar.drainMultiplier = baseDrainMultiplier * 1.5f;
        nbOfLaveries += 1;

    }
}

