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

    private CiseauxLevel _ciseauxLevel;// on commence avec des ciseaux en fer

    private MakeLeaves _makeLeaves;
    [SerializeField] public int nbAchat;
    private TextMeshProUGUI _prixTexte;
    private int _prix = 10;
    private Button _button;


    void Start()
    {
        _button = gameObject.GetComponent<Button>();
        _makeLeaves = FindObjectOfType<MakeLeaves>();
        _prixTexte = gameObject.GetComponentInChildren<TextMeshProUGUI>();
        _button.interactable = false;
        loadCiseaux();
        _ciseauxLevel = CiseauxLevel.None;
        Debug.Log(_ciseauxLevel);
    }

    public void achatCiseaux()//A METTRE SUR LE BOUTON D'ACHAT
    {
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
        Debug.Log(_ciseauxLevel);
    }

    public void CiseauxManager()
    {
        switch (_ciseauxLevel)
        {
            case CiseauxLevel.Fer:
                _makeLeaves.nbClicks = 2;
                _prix = 20;
                _prixTexte.text = "Acheter " + _prix + "$";
                break;

            case CiseauxLevel.Or:
                _makeLeaves.nbClicks = 10;
                _prix = 30;
                _prixTexte.text = "Acheter " + _prix + "$";
                break;

            case CiseauxLevel.Diamant:
                _makeLeaves.nbClicks = 100;
                _prixTexte.text = "Amélioration max";
                _button.interactable = false;
                _button.enabled = false;
                break;

            default:
                _prixTexte.text = "Acheter " + _prix + "$";
                break;

        }
    }

    public void saveCiseaux()
    {
        PlayerPrefs.SetInt("ciseauLevel", (int)_ciseauxLevel);
        PlayerPrefs.Save();
    }
    public void loadCiseaux()
    {
        _ciseauxLevel = (CiseauxLevel)PlayerPrefs.GetInt("ciseauLevel", 0);
    }
}
