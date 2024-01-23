using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PropreArgent : MonoBehaviour
{
    
    public static int argent;
   [SerializeField] private TextMeshProUGUI _argent;
    // Start is called before the first frame update
    
    void Update()
    {
        _argent.text = "Argent " + argent + "$";
    }
    
    public void cliquePropre()
    {
        if (GlobalLeaves.leafCount <= 0) return;
        argent += 1;
        GlobalLeaves.leafCount -= 1;
    }
}
