using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class suspiscionBar : MonoBehaviour
{
    public Slider susBar;

    [SerializeField] private float minSus = 0f;
    [SerializeField] private float maxSus = 20;
    public static float susGenRate = 1f;
    [SerializeField] private float susDrainRate = 1f;

    public static float genMultiplier = 1f;
    public static float drainMultiplier;


    public float currentSus;

    public static bool isSusBarFull = false;

    void Start()
    {
        currentSus = minSus;
        susBar.value = currentSus;
        StartCoroutine(generateSus());
        //saveBar();
        loadBar();
    }

    // Update is called once per frame
    void Update()
    {
        if (susBar.value == maxSus)
        {
            isSusBarFull = true;
            Debug.Log("GAME OVER");
        }
        Debug.Log("Gen rate = " + susGenRate + "genMultiplier : " + genMultiplier);
    }

    IEnumerator generateSus()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            // V�rifier si le joueur a suffisamment de feuilles pour augmenter la suspicion
            if (GlobalLeaves.leafCount >= 10)
            {
                // Augmenter la barre de suspicion
                susBar.value += susGenRate * genMultiplier;

                // V�rifier si la suspicion atteint le maximum
                if (susBar.value >= maxSus)
                {
                    Debug.Log("Game Over: Suspicion maximale atteinte!");
                    
                }
            }
        }
    }

    IEnumerator drainSus()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            // V�rifier si le joueur a suffisamment de feuilles pour augmenter la suspicion
            if (GlobalLeaves.leafCount >= 10)
            {
                // Augmenter la barre de suspicion
                susBar.value -= susDrainRate;

                // V�rifier si la suspicion atteint le maximum
                if (susBar.value <= minSus)
                {
                    Debug.Log("Game Over: Suspicion minimale atteinte!");
                    
                }
            }
        }
    }

    public void saveBar()
    {
        PlayerPrefs.SetFloat("susBar", susBar.value);
        PlayerPrefs.Save();
    }

    public void loadBar()
    {
        susBar.value = PlayerPrefs.GetFloat("susBar");
    }


}
