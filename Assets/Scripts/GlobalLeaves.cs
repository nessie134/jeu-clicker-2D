using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GlobalLeaves : MonoBehaviour
{
    public static int leafCount;
    private TextMeshProUGUI _argent;

    private void Start()
    {
        leafCount = 0;
        _argent = gameObject.GetComponentInChildren<TextMeshProUGUI>();
        //saveLeaf(); //si ça marche pas dans l'autre scene......?
        loadLeaf();
        Debug.Log(leafCount);
    }

    public void Update()
    {
        _argent.text = "Argent " + leafCount + "$";
    }

    public void saveLeaf()
    {
        PlayerPrefs.SetInt("nbCookies", leafCount);
        PlayerPrefs.Save();
    }

    public void loadLeaf()
    {
        leafCount = PlayerPrefs.GetInt("nbCookies");
    }
}
