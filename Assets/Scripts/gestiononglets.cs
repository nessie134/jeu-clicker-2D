using UnityEngine;
using UnityEngine.UI;

public class gestiononglets : MonoBehaviour
{   
   [SerializeField] private RectTransform _rectTransform;
   [SerializeField] private RectTransform _rectTransform2;

    private void Start()
    {
    }

    public void FlècheDroite()
    {
        _rectTransform.anchoredPosition = new Vector2(_rectTransform.anchoredPosition.x - 1924, _rectTransform.anchoredPosition.y);
        _rectTransform2.anchoredPosition = new Vector2(_rectTransform2.anchoredPosition.x - 1924, _rectTransform2.anchoredPosition.y);
    }

    public void FlècheGauche()
    {
        _rectTransform2.anchoredPosition = new Vector2(_rectTransform2.anchoredPosition.x + 1924, _rectTransform2.anchoredPosition.y);
        _rectTransform.anchoredPosition = new Vector2(_rectTransform.anchoredPosition.x + 1924, _rectTransform.anchoredPosition.y);
    }
    
}