using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changementScene : MonoBehaviour
{   
    private GlobalLeaves _globalLeaves;
    private ciseaux _ciseaux;
    private suspiscionBar _suspiscionBar;

    
    private void Start()
    {
        _globalLeaves = FindObjectOfType<GlobalLeaves>();
        _ciseaux = FindObjectOfType<ciseaux>();
        _suspiscionBar = FindObjectOfType<suspiscionBar>();
    }
    public void ChangeScene()
    {
        _globalLeaves.saveLeaf();
        _ciseaux.saveCiseaux();
        _suspiscionBar.saveBar();
        SceneManager.LoadScene(3);
    }
    
    public void loadArgentSale()
    {
        SceneManager.LoadScene(2);
    }
}
