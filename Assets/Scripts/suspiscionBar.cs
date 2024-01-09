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

    public float currentSus;

    public static bool isSusBarFull = false;

    void Start()
    {
        currentSus = minSus;
        susBar.value = currentSus;
        StartCoroutine(generateSus());
        saveBar();
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
        Debug.Log(susGenRate);
    }

    IEnumerator generateSus()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            // Vérifier si le joueur a suffisamment de feuilles pour augmenter la suspicion
            if (GlobalLeaves.leafCount >= 10)
            {
                // Augmenter la barre de suspicion
                susBar.value += susGenRate;

                // Vérifier si la suspicion atteint le maximum
                if (susBar.value == maxSus)
                {
                    Debug.Log("Game Over: Suspicion maximale atteinte!");
                    
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
