using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlerPersonnageGuillaume : MonoBehaviour
{
    public float vitesseX;      //vitesse en gauche et droite
    public float vitesseY;      //vitesse en haut et bas
    public float Vitesse;       //vitesse maximale

    bool glisse;                //si le joueur glisse
    bool porteBouffe;           //si le joueur porte de la bouffe
    bool joueurProcheTable = false;
    bool joueurProcheBouffe = false;

    public GameObject BouffeActuelle; //la bouffe que le joueur porte

    public GameObject[] ListeSpawnPourCommandes;
    public GameObject[] ListeBouffe;

    public GameObject closestObject;

    private Animator animator;

    public GameObject RefSons;

    void Start()
    {
        animator = this.GetComponent<Animator>();
        ListeSpawnPourCommandes = GameObject.FindGameObjectsWithTag("Spawn");

        ListeBouffe = GameObject.FindGameObjectsWithTag("Bouffe");

        for (int i = 0; i < ListeBouffe.Length; i++)
        {
            ListeBouffe[i].transform.position = ListeSpawnPourCommandes[Random.Range(0, ListeSpawnPourCommandes.Length)].transform.position;
        }
    }

    void Update()
    {
       Vector2 directionMouvement = Vector2.zero;
        var VitesseY =  Mathf.Round(Input.GetAxis("Vertical")) * Vitesse;
        var VitesseX = Mathf.Round(Input.GetAxis("Horizontal")) * Vitesse;

        GetComponent<Rigidbody2D>().velocity = new Vector2(vitesseX, vitesseY);

        if (VitesseX == 0)
        {
            directionMouvement.x = 0;
            directionMouvement.y = 0;
            animator.SetInteger("Direction", -1);
        }
        
        if (VitesseX > 0)
        {
            directionMouvement.x = 1;
            if (VitesseY < 0)
            {
                directionMouvement.x = 1;
                directionMouvement.y = -1;
            }

            else if (VitesseY > 0)
            {
                directionMouvement.x = 1;
                directionMouvement.y = 1;
            }
            animator.SetInteger("Direction", 2);
        }
        else if (VitesseX < 0)
        {
            directionMouvement.x = -1;
            if (VitesseY < 0)
            {
                directionMouvement.x = -1;
                directionMouvement.y = -1;
            }

            else if (VitesseY > 0)
            {
                directionMouvement.x = -1;
                directionMouvement.y = 1;
            }
            animator.SetInteger("Direction", 0);
        }
        else if (VitesseY > 0)
        {
            directionMouvement.y = 1;
            if (VitesseX < 0)
            {
                directionMouvement.x = -1;
                directionMouvement.y = 1;
            }

            else if (VitesseX > 0)
            {
                directionMouvement.x = 1;
                directionMouvement.y = 1;
            }
            animator.SetInteger("Direction", 1);
        }
        else if (VitesseY < 0)
        {
            directionMouvement.y = -1;
            if (VitesseX < 0)
            {
                directionMouvement.x = -1;
                directionMouvement.y = -1;
            }

            else if (VitesseX > 0)
            {
                directionMouvement.x = 1;
                directionMouvement.y = -1;
            }
            animator.SetInteger("Direction", 3);
        }
        transform.Translate(directionMouvement * Vitesse * Time.deltaTime, Space.World);


        // Si le joueur porte de la bouffe,
        if (porteBouffe)
        {
            // Affecter la position de la bouffe au personnage
            BouffeActuelle.transform.position = transform.position;
        }

        //Si le joueur est proche de la table et qu'il appuie sur E, prendre OU déposer la bouffe
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (joueurProcheBouffe)
            {
                //Pickup bouffe
                RamasserBouffe();
            }

            if (joueurProcheTable)
            {
                //Déposer table
                ServirBouffe();

            }
        }

        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Si le personnage entre en contact avec une mouche,
        if (collision.gameObject.tag == "Mouche")
        {
            // Insérer ici tout ce qui est nécessaire après le contact de la mouche
            Debug.Log("hit");
        }

        // Si le personnage entre en contact avec une flaque,
        if (collision.gameObject.tag == "Flaque")
        {
            // Appeler la fonction qui altère le mouvement du personnage
            StartCoroutine(EffetFlaque());
        }

        // Si le personnage entre en contact avec de la bouffe,
        if (collision.gameObject.tag == "Commande")
        {
            // Appeler la fonction qui fait ramasser la bouffe
            joueurProcheBouffe = true;
            closestObject = collision.gameObject;
        }

        // Si le personnage entre en contact avec une table
        if (collision.gameObject.tag == "Table")
        {
            //proche de la table
            joueurProcheTable = true;
            closestObject = collision.gameObject;
            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // Si le personnage entre en contact avec de la bouffe,
        if (collision.gameObject.tag == "Commande")
        {
            // Appeler la fonction qui fait ramasser la bouffe
            joueurProcheBouffe = false;
            
        }

        // Si le personnage entre en contact avec une table
        if (collision.gameObject.tag == "Table")
        {
            //proche de la table
            joueurProcheTable = false;
            

        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        
    }

    IEnumerator EffetFlaque()
    {
        // Si le personnage ne glisse pas,
        if (!glisse)
        {
            // Faire glisser le personnage
            glisse = true;

            // Inverser la vitesse de déplacement
            Vitesse *= -1;

            // Attendre 5 secondes
            yield return new WaitForSeconds(5);

            // Rétablir la vitesse de déplacement
            Vitesse *= -1;

            // Faire rétablir le personnage
            glisse = false;
        }
    }

    void RamasserBouffe()
    {
        // Faire porter la bouffe
        porteBouffe = true;

        // Sélectionner la bouffe
<<<<<<< Updated upstream
        BouffeActuelle = closestObject;
        BouffeActuelle.GetComponent<BoxCollider2D>().enabled = false;
=======
        BouffeActuelle = Bouffe;

        RefSons.GetComponent<GestionSonoreAmbiance>().JouerSons("Ramassage");
>>>>>>> Stashed changes
    }

    void ServirBouffe()
    {
        // S'il n'y a pas de bouffe dans les mains du joueur OU qu'il n'y a pas de bouffe sur la table,
        if (BouffeActuelle != null && closestObject.transform.childCount == 0)
        {
            // Ne plus faire porter la bouffe
            porteBouffe = false;

            
            // Mettre la bouffe en tant qu'enfant de la table
            BouffeActuelle.transform.parent = closestObject.transform;

            // Positionner la bouffe sur la table
            BouffeActuelle.transform.position = closestObject.transform.position;


            RefSons.GetComponent<GestionSonoreAmbiance>().JouerSons("Livraison");

            // Réinitialiser la bouffe actuelle
            BouffeActuelle = GameObject.Find(" ");
        }
    }
}