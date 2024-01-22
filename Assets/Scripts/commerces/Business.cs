using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Business : MonoBehaviour
{
    
    public string businessName;
    public int businessCost;
    private TextMeshProUGUI _text;
    private Button _button;
    private bool _isBought = false;
    public void Start()
    {
        _text = gameObject.GetComponentInChildren<TextMeshProUGUI>();
        _button = gameObject.GetComponent<Button>();
        _text.text = businessCost + "$";
    }
    public void Update()
    {
        if (_isBought == false)
        {
            if (PropreArgent.argent >= businessCost)
            {
                _button.interactable = true;
            }
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
    }

    public virtual void BusinessAction()
    {
        _isBought = true;
        _text.text = "Déjà acheté";
        PropreArgent.argent -= businessCost;
    }
}
