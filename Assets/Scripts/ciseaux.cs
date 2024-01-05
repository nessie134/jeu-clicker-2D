using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

public class ciseaux : MonoBehaviour
{
    private MakeCookies _makeCookies;
    [SerializeField] public int nbAchat;
    private TextMeshProUGUI _prixTexte;
    private int _prix = 10;
    private Button _button;
    [SerializeField] private TextMeshProUGUI _ciseaux;

    void Start()
    {
        _button = gameObject.GetComponent<Button>();
        _makeCookies = FindObjectOfType<MakeCookies>();
        _prixTexte = gameObject.GetComponentInChildren<TextMeshProUGUI>();
        loadCiseaux();
    }

    public void achatCiseaux()
    {
        nbAchat++;
        switch(nbAchat)
        {
            case 1:
                GlobalCookies.cookieCount -= _prix;
                break;
            case 2:
                GlobalCookies.cookieCount -= _prix;
                break;
            case 3:
                GlobalCookies.cookieCount -= _prix;
                _button.interactable = false;
                break;
        }
    }
    void Update()
    {
        
        switch (nbAchat)
        {
            case 1:
                _makeCookies.nbClicks = 2;
                _ciseaux.text = "Ciseaux en or";
                _prix = 250;
                _prixTexte.text = "Acheter " + _prix + "$";
                break;
            case 2:
                _makeCookies.nbClicks = 10;
                _ciseaux.text = "Ciseaux en diamant";
                _prix = 2000;
                _prixTexte.text = "Acheter " + _prix + "$";
                break;
            case 3:
                _makeCookies.nbClicks = 100;
                _prixTexte.text = "Amélioration max";
                _prix = 15000;
                break;
            default:_prixTexte.text = "Acheter " + _prix + "$";
                break;
        }
        
        
        if(GlobalCookies.cookieCount >= _prix)
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
        PlayerPrefs.SetInt("nbAchatCiseaux", nbAchat);
        PlayerPrefs.Save();
    }
    public void loadCiseaux()
    {
        nbAchat = PlayerPrefs.GetInt("nbAchatCiseaux", 0);
    }
}
