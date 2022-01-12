using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlerPersonnage : MonoBehaviour
{
    public float vitesseX;      //vitesse en gauche et droite
    public float vitesseY;      //vitesse en haut et bas
    public float Vitesse;


    /* Détection des touches et modification de la vitesse de déplacement;
       "a" et "d" pour avancer et reculer, "w" pour sauter
    */
    void Update()
    {
        vitesseY = Mathf.Round(Input.GetAxis("Vertical")) * Vitesse;
        vitesseX = Mathf.Round(Input.GetAxis("Horizontal")) * Vitesse;

        GetComponent<Rigidbody2D>().velocity = new Vector2(vitesseX, vitesseY);



    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Mouche")
        {
            Debug.Log("hit");
        }
    }
   
}