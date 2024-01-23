using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ferme : MonoBehaviour
{
    
    private TextMeshProUGUI _farmDesc;
    private int prix;
    private Button _button;
    public static int nbFarm;
    public static float genMultiplier = 0.6f;
    
    
    // Start is called before the first frame update
    void Start()
    {
        _farmDesc = gameObject.GetComponentInChildren<TextMeshProUGUI>();
        prix = 20000;
        _button = gameObject.GetComponent<Button>();
        StartCoroutine(Farm());
    }
    
    public void achatFerme()
    {
        AudioManager.Instance.PlaySfx("clickUpgrade", 1f);
        GlobalLeaves.leafCount -= prix;
        nbFarm += 1000;
        prix += 10000;
        genMultiplier += 0.2f;
    }
    void Update()
    {
        _farmDesc.text = "Acheter " + prix + "$";
        _button.interactable = GlobalLeaves.leafCount >= prix;
    }
    IEnumerator Farm()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            GlobalLeaves.leafCount += nbFarm;
        }
    }
}