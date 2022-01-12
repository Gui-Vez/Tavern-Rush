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
       "a" et "d" pour aller a gauche et a droite, "w" et "s" pour en haut et en bas */
    
    private Animator animator;
 
    // Use this for initialization
    void Start()
    {
        animator = this.GetComponent<Animator>();
    }
 
    // Update is called once per frame
    void Update()
    {
        
    }

    /* Détection des touches et modification de la vitesse de déplacement;
       "a" et "d" pour avancer et reculer, "w" pour sauter
    */

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Si le personnage entre en contact avec la mouche
        if (collision.gameObject.tag == "Mouche")
        {
        // Insérer ici tout ce qui est nécessaire après le contact de la mouche
        }
    }
   
}