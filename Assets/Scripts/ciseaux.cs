using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

public class ciseaux : MonoBehaviour
{
    public enum CiseauxLevel
    {
        None,
        Fer,
        Or,
        Diamant
    };

    private CiseauxLevel _ciseauxLevel;

    private MakeLeaves _makeLeaves;
    private TextMeshProUGUI _prixTexte;
    private int _prix = 10;
    private Button _button;
    [SerializeField] private TextMeshProUGUI _description;

    public static float genMultiplier;


    void Start()
    {
        _button = gameObject.GetComponent<Button>();
        _makeLeaves = FindObjectOfType<MakeLeaves>();
        _prixTexte = gameObject.GetComponentInChildren<TextMeshProUGUI>();
    }

    public void achatCiseaux()
    {
        AudioManager.Instance.PlaySfx("clickUpgrade", 1f);
        switch (_ciseauxLevel)
        {
            case CiseauxLevel.None:
            case CiseauxLevel.Fer:
            case CiseauxLevel.Or:
                GlobalLeaves.leafCount -= _prix;
                break;
            case CiseauxLevel.Diamant:
                _button.interactable = false;
                break;
        }
        _ciseauxLevel++;
        
    }

    void Update()
    {
        CiseauxManager();

        if (GlobalLeaves.leafCount >= _prix)
        {
            _button.interactable = true;
        }
        else
        {
            _button.interactable = false;
        }
        //Debug.Log("Level ciseau " + _ciseauxLevel);
    }

    public void CiseauxManager()
    {
        switch (_ciseauxLevel)
        {
            case CiseauxLevel.Fer:
                _makeLeaves.nbClicks = 2;
                _prix = 20;
                _prixTexte.text = "Acheter " + _prix + "$";
                _description.text = "Ciseaux en or";
                genMultiplier = 1.2f;
                break;

            case CiseauxLevel.Or:
                _makeLeaves.nbClicks = 10;
                _prix = 30;
                _prixTexte.text = "Acheter " + _prix + "$";
                _description.text = "Ciseaux en diamant";
                genMultiplier = 1.5f;
                break;

            case CiseauxLevel.Diamant:
                _makeLeaves.nbClicks = 100;
                _prixTexte.text = "Amélioration max";
                _button.interactable = false;
                genMultiplier = 2f;
                break;

            default:
                _prixTexte.text = "Acheter " + _prix + "$";
                break;

        }
    }
    
}
