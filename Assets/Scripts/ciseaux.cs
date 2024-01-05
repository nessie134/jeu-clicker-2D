using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

public class ciseaux : MonoBehaviour
{
    private MakeLeaves _makeLeaves;
    [SerializeField] public int nbAchat;
    private TextMeshProUGUI _prixTexte;
    private int _prix = 10;
    private Button _button;
    [SerializeField] private TextMeshProUGUI _ciseaux;

    void Start()
    {
        _button = gameObject.GetComponent<Button>();
        _makeLeaves = FindObjectOfType<MakeLeaves>();
        _prixTexte = gameObject.GetComponentInChildren<TextMeshProUGUI>();
        loadCiseaux();
    }

    public void achatCiseaux()
    {
        nbAchat++;
        switch(nbAchat)
        {
            case 1:
                GlobalLeaves.leafCount -= _prix;
                break;
            case 2:
                GlobalLeaves.leafCount -= _prix;
                break;
            case 3:
                GlobalLeaves.leafCount -= _prix;
                _button.interactable = false;
                break;
        }
    }
    void Update()
    {
        
        switch (nbAchat)
        {
            case 1:
                _makeLeaves.nbClicks = 2;
                _ciseaux.text = "Ciseaux en or";
                _prix = 250;
                _prixTexte.text = "Acheter " + _prix + "$";
                break;
            case 2:
                _makeLeaves.nbClicks = 10;
                _ciseaux.text = "Ciseaux en diamant";
                _prix = 2000;
                _prixTexte.text = "Acheter " + _prix + "$";
                break;
            case 3:
                _makeLeaves.nbClicks = 100;
                _prixTexte.text = "Amélioration max";
                _prix = 15000;
                break;
            default:_prixTexte.text = "Acheter " + _prix + "$";
                break;
        }
        
        
        if(GlobalLeaves.leafCount >= _prix)
        {
            _button.interactable = true;
        }
        else
        {
            _button.interactable = false;
        }
    }

    public void saveCiseaux()
    {
        PlayerPrefs.SetInt("nbAchatCiseaux", nbAchat);// PlayerPrefs data is stored locally on the player's device and is not encrypted,
                                                      // making it susceptible to easy access and manipulation
        PlayerPrefs.Save();
    }
    public void loadCiseaux()
    {
        nbAchat = PlayerPrefs.GetInt("nbAchatCiseaux", 0);
    }
}
