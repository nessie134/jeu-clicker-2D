using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PropreArgent : MonoBehaviour
{
    
    public static int argent;
    private TextMeshProUGUI _argent;
    // Start is called before the first frame update
    void Start()
    {
        _argent = gameObject.GetComponentInChildren<TextMeshProUGUI>();
    }

    void Update()
    {
        _argent.text = "Argent " + argent + "$";
    }

    public void cliquePropre()
    {
        argent += 1;
    }
}
