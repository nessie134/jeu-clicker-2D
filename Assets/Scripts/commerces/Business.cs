using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Business : MonoBehaviour
{
    private TextMeshProUGUI _prixTexte;
    public string businessName;
    //public int businessLevel;
    public int businessCost;
    private Button _button;

    public void Start()
    {
        _button = gameObject.GetComponent<Button>();
        _prixTexte = gameObject.GetComponentInChildren<TextMeshProUGUI>();
    }

    private void Update()
    {
        if (GlobalLeaves.leafCount >= businessCost)
        {
            _button.interactable = true;
        }
        else
        {
            _button.interactable = false;
        }
    }

    public Business(string name, int cost)
    {
        businessName = name;
        businessCost = cost;

        _prixTexte.text = "Acheter " + cost + "$";
    }

    public virtual void BusinessAction()
    {
        GlobalLeaves.leafCount -= businessCost;
    }
}
