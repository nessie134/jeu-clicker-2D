using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changementScene : MonoBehaviour
{   
    private GlobalCookies _globalCookies;
    private ciseaux _ciseaux;

    
    private void Start()
    {
        _globalCookies = FindObjectOfType<GlobalCookies>();
        _ciseaux = FindObjectOfType<ciseaux>();
    }
    public void ChangeScene()
    {
        _globalCookies.saveCookie();
        _ciseaux.saveCiseaux();
        SceneManager.LoadScene("Argent Propre Adrien");
    }
    
    public void loadArgentSale()
    {
        SceneManager.LoadScene("Adrien Game");
    }
}
