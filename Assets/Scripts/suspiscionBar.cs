using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class suspiscionBar : MonoBehaviour
{
    public Slider susBar;
    
    public GameObject ImgGameOver;

    [SerializeField] private float minSus = 0f;
    [SerializeField] private float maxSus = 100f;
    public static float susGenRate = 1f;
    public float susDrainRate = 1f;

    public static float genMultiplier;
    public static float drainMultiplier;


    private float currentSus;

    public static bool isSusBarFull = false;

    void Start()
    {
        genMultiplier = 1f; drainMultiplier = 1f;
        
        susBar.value = minSus;
        StartCoroutine(generateSus());
        StartCoroutine(drainSus());
    }

    // Update is called once per frame
    void Update()
    {
        currentSus = susBar.value;
        if (genMultiplier == 0)
        {
            genMultiplier = 1;
        }
        else
        {
            genMultiplier = GlobalEmployee.genMultiplier * GlobalEmployee.nbOfEmployees +
                                        ciseaux.genMultiplier +
                                        ferme.genMultiplier * ferme.nbFarm +
                                        hangar.genMultiplier * hangar.nbHangar +
                                        robots.genMultiplier * robots.nbRobots;

            drainMultiplier = bar.drainMultiplier * bar.nbOfBars +
                                        hotel.drainMultiplier * hotel.nbOfHotel +
                                        fastfood.drainMultiplier * fastfood.nbOfFf +
                                        casino.drainMultiplier * casino.nbOfCas +
                                        Laverie.drainMultiplier * Laverie.nbOfLaveries;

            Debug.Log("Multiplicateur de gen global = " + genMultiplier);
            Debug.Log("Multiplicateur de drain global = " + genMultiplier);

        }

        if (susBar.value > maxSus)
        {
            susBar.value = maxSus;
        }


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
                susBar.value += susGenRate * genMultiplier;

                // Vérifier si la suspicion atteint le maximum

            }
            if (susBar.value == maxSus)
            {
                
                
                Debug.Log("GAME OVER: Suspicion maximale atteinte!" + susBar.value);
                AudioManager.Instance.musicSource.Stop();
                AudioManager.Instance.PlaySfx("game over", 0.5f);
                GameOver();
                

            }
        }
    }

    IEnumerator drainSus()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            // Vérifier si le joueur a suffisamment de feuilles pour augmenter la suspicion
            if (GlobalLeaves.leafCount >= 10)
            {
                // Augmenter la barre de suspicion
                susBar.value -= susGenRate * drainMultiplier;
            }

            // Vérifier si la suspicion atteint le maximum
            if (susBar.value <= minSus)
            {
                Debug.Log("Suspicion minimale atteinte!");

            }
        }
    }

    IEnumerator LoadMenu()
    {
        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene("Menu");
        AudioManager.Instance.sfxSource.Stop();
    }

    public void GameOver() //On va récup cette méthode dans le script CountDown
    {
        ImgGameOver.SetActive(true);//Désactivé dans l'éditeur!
        StartCoroutine(LoadMenu());
    }

   


}
