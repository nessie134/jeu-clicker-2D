using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class robots : MonoBehaviour
{
    
    private TextMeshProUGUI _robotsDesc;
    private int prix;
    private Button _button;
    public static int nbRobots;
    public static float genMultiplier = 0.3f;
    
    
    // Start is called before the first frame update
    void Start()
    {
        _robotsDesc = gameObject.GetComponentInChildren<TextMeshProUGUI>();
        prix = 100;
        _button = gameObject.GetComponent<Button>();
        StartCoroutine(Farm());
    }
    
    public void achatRobots()
    {
        AudioManager.Instance.PlaySfx("clickUpgrade", 1f);
        GlobalLeaves.leafCount -= prix;
        nbRobots += 10;
        prix += 200;
        genMultiplier += 0.1f;
    }
    void Update()
    {
        _robotsDesc.text = "Acheter " + prix + "$";
        _button.interactable = GlobalLeaves.leafCount >= prix;
    }
    IEnumerator Farm()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            GlobalLeaves.leafCount += nbRobots;
        }
    }
}
