using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PurchaseLog : MonoBehaviour
{
    public GameObject autoLeaf;
    [SerializeField] private TextMeshProUGUI _nbOfEmployees; 
    public void StartAutoLeaf()//� mettre sur le bouton
    {
        autoLeaf.SetActive(true);
        AudioManager.Instance.PlaySfx("clickUpgrade", 1f);

        GlobalLeaves.leafCount -= GlobalEmployee.employeeValue;//On retire le prix de l'employ� au nombre de feuilles
        GlobalEmployee.employeeValue *= 2;//Chaque fois qu'on ach�te un employ�, on double son prix
        GlobalEmployee.nbOfEmployees += 1;//On augmente le nombre d'employ�s
        GlobalEmployee.turnOffButton = true;//On d�sactive le bouton pour �viter de spam l'achat alors qu'on a pas assez de feuilles

        GlobalEmployee.employeeLeavesPerSec += 1;
    }

    public void Update()
    {
        _nbOfEmployees.text = "Employ�s : " + GlobalEmployee.nbOfEmployees;
    }
}
