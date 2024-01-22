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
    }

    public void Update()
    {
        _argent.text = "Argent " + leafCount + "$";
    }
    
}
