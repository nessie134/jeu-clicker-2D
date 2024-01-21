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
            // Ajoutez ici des actions sp�cifiques au Game Over (chargement de sc�ne, d�sactivation de contr�les, etc.)
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
                // G�n�ration de la barre de suspicion
                currentSus += susGenRate * genMultiplier;

                // Drainage de la barre de suspicion
                currentSus -= susDrainRate * drainMultiplier;

                // Assurez-vous que la valeur reste dans la plage d�finie
                currentSus = Mathf.Clamp(currentSus, minSus, maxSus);

                // Mettez � jour la valeur de la barre de suspicion
                susBar.value = currentSus;
            }
        }
    }

    // ... Autres m�thodes et fonctions n�cessaires

    public void PauseGame()
    {
        isGamePaused = true;
    }

    public void ResumeGame()
    {
        isGamePaused = false;
    }
}
