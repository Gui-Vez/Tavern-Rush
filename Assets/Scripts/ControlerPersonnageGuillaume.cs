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
    
    public GameObject BouffeActuelle; //la bouffe que le joueur porte

    public GameObject[] ListeSpawnPourCommandes;
    public GameObject[] ListeBouffe;

    void Start()
    {
        ListeSpawnPourCommandes = GameObject.FindGameObjectsWithTag("Spawn");

        ListeBouffe = GameObject.FindGameObjectsWithTag("Bouffe");

        for (int i = 0; i < ListeBouffe.Length; i++)
        {
            ListeBouffe[i].transform.position = ListeSpawnPourCommandes[Random.Range(0, ListeSpawnPourCommandes.Length)].transform.position;
        }
    }

    void Update()
    {
        /* Détection des touches et modification de la vitesse de déplacement;
       "A" et "D" pour bouger horizontalement
       "W" et "S" pour bouger verticalement */
        vitesseY = Mathf.Round(Input.GetAxis("Vertical")) * Vitesse;
        vitesseX = Mathf.Round(Input.GetAxis("Horizontal")) * Vitesse;

        // Appliquer les vitesses à la vélocité du personnage
        GetComponent<Rigidbody2D>().velocity = new Vector2(vitesseX, vitesseY);


        // Si le joueur porte de la bouffe,
        if (porteBouffe)
        {
            // Affecter la position de la bouffe au personnage
            BouffeActuelle.transform.position = transform.position;
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
        if (collision.gameObject.tag == "Bouffe")
        {
            // Appeler la fonction qui fait ramasser la bouffe
            RamasserBouffe(collision.gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Si le personnage entre en contact avec une table
        if (collision.gameObject.tag == "Table")
        {
            // Appeler la fonction qui vérifie si la bouffe est celle demandée
            VerifierBouffe(collision.gameObject);
        }
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

    void RamasserBouffe(GameObject Bouffe)
    {
        // Faire porter la bouffe
        porteBouffe = true;

        // Sélectionner la bouffe
        BouffeActuelle = Bouffe;
    }

    void VerifierBouffe(GameObject Table)
    {
        // S'il n'y a pas de bouffe dans les mains du joueur OU qu'il n'y a pas de bouffe sur la table,
        if (BouffeActuelle != null && Table.transform.childCount == 0)
        {
            // Ne plus faire porter la bouffe
            porteBouffe = false;


            // Mettre la bouffe en tant qu'enfant de la table
            BouffeActuelle.transform.parent = Table.transform;

            // Positionner la bouffe sur la table
            BouffeActuelle.transform.position = Table.transform.position;


            // Réinitialiser la bouffe actuelle
            BouffeActuelle = GameObject.Find(" ");
        }
    }
}