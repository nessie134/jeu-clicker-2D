using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

public class ciseaux : MonoBehaviour
{
    private MakeCookies _makeCookies;
    [SerializeField] private int nbAchat = 0;
    private TextMeshProUGUI _prixTexte;
    private int _prix = 75;
    private Button _button;
    [SerializeField] private TextMeshProUGUI _ciseaux;

    void Start()
    {
        _button = gameObject.GetComponent<Button>();
        _makeCookies = FindObjectOfType<MakeCookies>();
        _prixTexte = gameObject.GetComponentInChildren<TextMeshProUGUI>();
    }

    public void achatCiseaux()
    {
        nbAchat++;
        if (nbAchat == 1)
        {   
            _ciseaux.text = "Ciseaux en fer";
            _makeCookies.nbClicks = 2;
            GlobalCookies.cookieCount -= _prix;
            _prix = 250;
        }
        else if (nbAchat == 2)
        {
            _ciseaux.text = "Ciseaux en or";
            _makeCookies.nbClicks = 10;
            GlobalCookies.cookieCount -= _prix;
            _prix = 2000;
        }
        else if (nbAchat == 3)
        {
            _ciseaux.text = "Ciseaux en diamant";
            _makeCookies.nbClicks = 100;
            GlobalCookies.cookieCount -= _prix;
            _button.interactable = false;
        }
        
    }
    void Update()
    {
        if (nbAchat == 3)
        {
            _prixTexte.text = "Amélioration max";
        }
        else
        {
            _prixTexte.text = "Acheter " + _prix + "$";
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
}
