using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurchaseLog : MonoBehaviour
{
    public GameObject autoLeaf;//on cr�er un gameObject solo sur lequel on met le script de l'auto leaf car on doit l'activer(d�sactiv� au d�but du jeu)
    public void StartAutoLeaf()//� mettre sur le bouton
    {
        autoLeaf.SetActive(true);

        GlobalLeaves.leafCount -= GlobalEmployee.employeeValue;//On retire le prix de l'employ� au nombre de feuilles
        GlobalEmployee.employeeValue *= 2;//Chaque fois qu'on ach�te un employ�, on double son prix
        GlobalEmployee.nbOfEmployees += 1;//On augmente le nombre d'employ�s
        GlobalEmployee.turnOffButton = true;//On d�sactive le bouton pour �viter de spam l'achat alors qu'on a pas assez de feuilles

        GlobalEmployee.employeeLeavesPerSec += 1;
        suspiscionBar.genMultiplier = GlobalEmployee.genMultiplier * GlobalEmployee.nbOfEmployees + ciseaux.genMultiplier;
        suspiscionBar.drainMultiplier = Laverie.drainMultiplier * Laverie.nbOfLaveries +
                                        bar.drainMultiplier * bar.nbOfBars + 
                                        hotel.drainMultiplier * hotel.nbOfHotel +
                                        fastfood.drainMultiplier * fastfood.nbOfFf +
                                        casino.drainMultiplier * casino.nbOfCas;
    }

    public void Update()
    {
        /*Debug.Log("nombre d'employ�s : " + GlobalEmployee.nbOfEmployees);
        Debug.Log("nombre de feuilles des employ�s : " + GlobalEmployee.employeeLeavesPerSec);*/
        Debug.Log("Multiplicateur de gen global = " + suspiscionBar.genMultiplier);
        Debug.Log("Multiplicateur de drain global = " + suspiscionBar.genMultiplier);
    }
}
