using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class hangar : MonoBehaviour
{
    
    private TextMeshProUGUI _hangarDesc;
    private int prix;
    private Button _button;
    public static int nbHangar;
    public static float genMultiplier = 10f;
    
    
    // Start is called before the first frame update
    void Start()
    {
        _hangarDesc = gameObject.GetComponentInChildren<TextMeshProUGUI>();
        prix = 100000;
        _button = gameObject.GetComponent<Button>();
        StartCoroutine(Farm());
    }
    
    public void achatHangar()
    {
        AudioManager.Instance.PlaySfx("clickUpgrade", 1f);
        GlobalLeaves.leafCount -= prix;
        nbHangar += 10000;
        prix += 50000;
        genMultiplier += 3f;
    }
    void Update()
    {
        _hangarDesc.text = "Acheter " + prix + "$";
        _button.interactable = GlobalLeaves.leafCount >= prix;
    }
    IEnumerator Farm()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            GlobalLeaves.leafCount += nbHangar;
        }
    }
}