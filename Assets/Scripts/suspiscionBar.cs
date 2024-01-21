using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class suspicionBar : MonoBehaviour
{
    public Slider susBar;

    [SerializeField] private float minSus = 0f;
    [SerializeField] private float maxSus = 20f;
    [SerializeField] private float susGenRate = 1f;
    [SerializeField] private float susDrainRate = 1f;

    private float currentSus;

    public float genMultiplier = 1f;
    public float drainMultiplier = 1f;

    private bool isSusBarFull = false;

    private bool isGamePaused = false;

    void Start()
    {
        currentSus = minSus;
        susBar.value = currentSus;
        StartCoroutine(GenerateAndDrain());
        //saveBar();
        //loadBar();
    }

    void Update()
    {
        if (currentSus >= maxSus)
        {
            isSusBarFull = true;
            Debug.Log("GAME OVER");
            // Ajoutez ici des actions spécifiques au Game Over (chargement de scène, désactivation de contrôles, etc.)
        }

        Debug.Log("susBar.value: " + susBar.value);
        Debug.Log("genMultiplier: " + genMultiplier);
        Debug.Log("drainMultiplier: " + drainMultiplier);
    }

    IEnumerator GenerateAndDrain()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);

            if (!isGamePaused)
            {
                // Génération de la barre de suspicion
                currentSus += susGenRate * genMultiplier;

                // Drainage de la barre de suspicion
                currentSus -= susDrainRate * drainMultiplier;

                // Assurez-vous que la valeur reste dans la plage définie
                currentSus = Mathf.Clamp(currentSus, minSus, maxSus);

                // Mettez à jour la valeur de la barre de suspicion
                susBar.value = currentSus;
            }
        }
    }

    // ... Autres méthodes et fonctions nécessaires

    public void PauseGame()
    {
        isGamePaused = true;
    }

    public void ResumeGame()
    {
        isGamePaused = false;
    }
}
