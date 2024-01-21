using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MakeLeaves : MonoBehaviour
{
    public int nbClicks = 1;

    public void ClickTheButton()
    {
        GlobalLeaves.leafCount += nbClicks;
        Debug.Log("Feuilles totales : " + GlobalLeaves.leafCount);
        AudioManager.Instance.PlaySfx("clickLeaf", 1f);
    }
}
