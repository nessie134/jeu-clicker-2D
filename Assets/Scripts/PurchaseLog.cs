using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurchaseLog : MonoBehaviour
{
    public GameObject autoLeaf;//on créer un gameObject solo sur lequel on met le script de l'auto leaf car on doit l'activer(désactivé au début du jeu)
    public void StartAutoLeaf()//à mettre sur le bouton
    {
        autoLeaf.SetActive(true);

        GlobalLeaves.leafCount -= GlobalEmployee.employeeValue;//On retire le prix de l'employé au nombre de feuilles
        GlobalEmployee.employeeValue *= 2;//Chaque fois qu'on achète un employé, on double son prix
        GlobalEmployee.nbOfEmployees += 1;//On augmente le nombre d'employés
        GlobalEmployee.turnOffButton = true;//On désactive le bouton pour éviter de spam l'achat alors qu'on a pas assez de feuilles

        GlobalEmployee.employeeLeavesPerSec += 1;

    }

    public void Update()
    {
        /*Debug.Log("nombre d'employés : " + GlobalEmployee.nbOfEmployees);
        Debug.Log("nombre de feuilles des employés : " + GlobalEmployee.employeeLeavesPerSec);*/

    }
}
