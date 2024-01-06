using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changementScene : MonoBehaviour
{   
    private GlobalLeaves _globalLeaves;
    private ciseaux _ciseaux;

    
    private void Start()
    {
        _globalLeaves = FindObjectOfType<GlobalLeaves>();
        _ciseaux = FindObjectOfType<ciseaux>();
    }
    public void ChangeScene()
    {
        _globalLeaves.saveLeaf();
        _ciseaux.saveCiseaux();
        SceneManager.LoadScene("argentPropreInes");
    }
    
    public void loadArgentSale()
    {
        SceneManager.LoadScene("GameInes");
    }
}
