using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleLanguage : MonoBehaviour
{
    public Lean.Localization.LeanLocalization leanScript;
    public Button changeLanguage;
    int langIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        changeLanguage.onClick.AddListener(() => ToggleLan()); 
    }

    void ToggleLan()
    {
        if (langIndex == 0)
        {
            leanScript.SetCurrentLanguage(1);
        }

        if (langIndex == 1)
        {
           leanScript.SetCurrentLanguage(0);
        }
    }
}
