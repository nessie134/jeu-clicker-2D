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
    public static float genMultiplier = 2f;
    
    
    // Start is called before the first frame update
    void Start()
    {
        _robotsDesc = gameObject.GetComponentInChildren<TextMeshProUGUI>();
        prix = 100;
        _button = gameObject.GetComponent<Button>();
    }
    
    public void achatRobots()
    {
        AudioManager.Instance.PlaySfx("clickUpgrade", 1f);
        GlobalLeaves.leafCount -= prix;
        prix += 200;
        nbRobots++;
        genMultiplier += 0.2f;
        StartCoroutine(Farm());
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
            GlobalLeaves.leafCount += 10 * nbRobots;
        }
    }
}
