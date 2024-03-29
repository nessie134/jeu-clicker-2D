using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class suspiscionBar : MonoBehaviour
{
    public Slider susBar;

    [SerializeField] private float minSus = 0f;
    [SerializeField] private float maxSus = 100f;
    public static float susGenRate = 1f;
    public float susDrainRate = 1f;

    public static float genMultiplier = 1f;
    public static float drainMultiplier;


    private float currentSus;

    public static bool isSusBarFull = false;

    void Start()
    {
        
        susBar.value = minSus;
        StartCoroutine(generateSus());
        StartCoroutine(drainSus());
        //saveBar();
        loadBar();
    }

    // Update is called once per frame
    void Update()
    {
        currentSus = susBar.value;
        Debug.Log("current sus : " + currentSus);
        Debug.Log("max sus : " + maxSus);
        /*Debug.Log("Gen rate = " + susGenRate + "genMultiplier : " + genMultiplier);
        Debug.Log("drain rate = " + drainMultiplier);
        Debug.Log("Nombre de laveries : " + Laverie.nbOfLaveries);*/
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

            }
            if (susBar.value >= maxSus)
            {
                
                Debug.Log("GAME OVER: Suspicion maximale atteinte!" + susBar.value);
                AudioManager.Instance.musicSource.Stop();
                AudioManager.Instance.PlaySfx("game over", 0.5f);
                Time.timeScale = 0f; // Pause the game

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
                susBar.value -= susGenRate * drainMultiplier;
            }

            // V�rifier si la suspicion atteint le maximum
            if (susBar.value <= minSus)
            {
                Debug.Log("Game Over: Suspicion minimale atteinte!");

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
