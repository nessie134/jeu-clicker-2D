using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UIElements;

public class ciseaux : MonoBehaviour
{
    private MakeCookies _makeCookies;
    private int nbAchat = 0;
    private TextMeshProUGUI _prixTexte;
    private int prix = 70;
    private bool canAcheter = false;
    void Start()
    {
        _makeCookies = FindObjectOfType<MakeCookies>();
        _prixTexte = gameObject.GetComponentInChildren<TextMeshProUGUI>();
    }

    public void achatCiseaux()
    {
        nbAchat++;
        if (nbAchat == 1 && canAcheter)
        {
            _makeCookies.nbClicks = 2;
            GlobalCookies.cookieCount -= prix;
            prix = 700;
            canAcheter = false;
        }
        
    }
    void Update()
    {
        _prixTexte.text = "Acheter " + prix + "$";
        if(GlobalCookies.cookieCount >= prix)
        {
            canAcheter = true;
            gameObject.GetComponent<Button>().normalColor = Color.green;
        }
        else
        {
            canAcheter = false;
        }
    }
}
