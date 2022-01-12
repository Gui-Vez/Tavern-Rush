using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/* Gestion de déplacement et du saut du personnage à l'aide des touches : a, d et w      
* Gestion des détections de collision entre le personnage et les objets du jeu  
* Par: Vahik Toroussian
* Modifié: 5/12/2018
*/
public class ControlerPersonnage : MonoBehaviour
{
    public float vitesseX;      //vitesse horizontale actuelle
    public float vitesseXMax;   //vitesse horizontale Maximale désirée
    public float vitesseY;      //vitesse verticale 
    public float vitesseSaut;   //vitesse de saut désirée
    public AudioClip SonsMort;
    public bool saut = true;
    public float VitesseMaximale;
    public GameObject barriereR;
    public GameObject barriereB;
    public GameObject barriereJ;
    public GameObject intouchable;
    public string niveau;
    public string niveauS;
    public AudioClip mort1;
    //public int score = 0;
    //public Text txtScore;


    /* Détection des touches et modification de la vitesse de déplacement;
       "a" et "d" pour avancer et reculer, "w" pour sauter
    */
    void Update()
    {
        // déplacement vers la gauche
        if (Input.GetKey("a") || Input.GetKey("left"))
        {
            vitesseX = -vitesseXMax;
            //GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (Input.GetKey("d") || Input.GetKey("right"))   //déplacement vers la droite
        {
            vitesseX = vitesseXMax;
            //GetComponent<SpriteRenderer>().flipX = false;
        }
        else
        {
            vitesseX = GetComponent<Rigidbody2D>().velocity.x;  //mémorise vitesse actuelle en X
        }

        // sauter l'objet à l'aide la touche "w"

        if (Input.GetKeyDown("w") || Input.GetKeyDown("up"))
        {
            if (Physics2D.OverlapCircle(transform.position, 0.333333f))
            {
                vitesseY = vitesseSaut;
                //GetComponent<Animator>().SetBool("saut", true);
            }
        }
        else
        {
            vitesseY = GetComponent<Rigidbody2D>().velocity.y;  //vitesse actuelle verticale

        }
        if(transform.position.x >= 9)
        {
            Invoke("Suivant", 0.1f);
        }
        if (Input.GetKeyDown("escape"))
        {
            Invoke("Menu", 0.1f);
        }
        /*if (Input.GetKeyDown("space"))
        {
            if (PeutAttaquer == true && GetComponent<Animator>().GetBool("saut") == false)
            {
                GetComponent<Animator>().SetBool("attaque", true);
                PeutAttaquer = false;
                if (GetComponent<SpriteRenderer>().flipX == true)
                {
                    vitesseX = -VitesseMaximale;
                }
                else if (GetComponent<SpriteRenderer>().flipX == false)
                {
                    vitesseX = VitesseMaximale;
                }
                Invoke("AttaqueCoolDown", 0.5f);
            }
        }*/

        //Applique les vitesses en X et Y
        GetComponent<Rigidbody2D>().velocity = new Vector2(vitesseX, vitesseY);


        //**************************Gestion des animaitons de course et de repos********************************
        //Active l'animation de course si la vitesse de déplacement n'est pas 0, sinon le repos sera jouer par Animator
        /*if (vitesseX > 0.1f || vitesseX < -0.1f)
        {
            GetComponent<Animator>().SetBool("marche", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("marche", false);
        }*/



    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        /*if (Physics2D.OverlapCircle(transform.position, 0.25f))
        {
            GetComponent<Animator>().SetBool("saut", false);
        }*/
        if (collision.gameObject.name == "Isometric Diamond")
        {
            GetComponent<Animator>().SetBool("mort", true);
            GetComponent<AudioSource>().enabled = true;
            //collision.gameObject.GetComponent<SpriteRenderer>().Layer = 5;
            Invoke("Reload", 0.7f);
        }
        if (collision.gameObject.name == "boutonR")
        {
            collision.gameObject.GetComponent<Animator>().enabled = true;
            barriereR.SetActive(false);
        }
        if (collision.gameObject.name == "boutonB")
        {
            collision.gameObject.GetComponent<Animator>().enabled = true;
            barriereB.SetActive(false);
        }
        if (collision.gameObject.name == "boutonJ")
        {
            collision.gameObject.GetComponent<Animator>().enabled = true;
            barriereJ.SetActive(false);
        }
        if (collision.gameObject.name == "boutonI")
        {
            collision.gameObject.GetComponent<Animator>().enabled = true;
            intouchable.SetActive(true);
        }

    }
    void Reload()
    {
        SceneManager.LoadScene(niveau);
    }
    void Suivant()
    {
        SceneManager.LoadScene(niveauS);
    }
    void Menu()
    {
        SceneManager.LoadScene("Menu");
    }
    /*void AttaqueCoolDown()
    {
        PeutAttaquer = true;
        GetComponent<Animator>().SetBool("attaque", false);
    }*/

}

