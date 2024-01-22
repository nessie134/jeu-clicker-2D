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
    public static float genMultiplier = 3f;
    
    
    // Start is called before the first frame update
    void Start()
    {
        _farmDesc = gameObject.GetComponentInChildren<TextMeshProUGUI>();
        prix = 20000;
        _button = gameObject.GetComponent<Button>();
    }
    
    public void achatFerme()
    {
        AudioManager.Instance.PlaySfx("clickUpgrade", 1f);
        GlobalLeaves.leafCount -= prix;
        nbFarm++;
        prix += 10000 * nbFarm;
        genMultiplier += 0.7f;
        StartCoroutine(Farm());
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
            GlobalLeaves.leafCount += 1000 * nbFarm;
        }
    }
}