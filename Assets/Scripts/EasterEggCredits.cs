using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasterEggCredits : MonoBehaviour
{
    public GameObject Credits;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Ouvrir menu crédits
            Time.timeScale = 0;
            Credits.SetActive(true);

            print("Clicked on easter egg");
        }
    }

    public void QuitEasterEgg()
    {
        //Fermer menu crédits
        Time.timeScale = 1;
        Credits.SetActive(false);
    }
}
