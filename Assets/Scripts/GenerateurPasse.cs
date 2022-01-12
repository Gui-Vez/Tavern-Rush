using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class GenerateurPasse : MonoBehaviour
{
    public GameObject[] plats;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Commande2());
    }

    IEnumerator Commande2()
    {
        while (true)
        {
            // Faire respirer la coroutine à chaque 10 secondes
            yield return new WaitForSeconds(2f);
            
            //Génération d'un ennemi au hasard
            int platHasard = Random.Range(0, 2);
            GameObject insanceAutrePlat = Instantiate(plats[platHasard], plats[platHasard].transform.position, plats[platHasard].transform.rotation);
            insanceAutrePlat.SetActive(true);
            //GetComponent<Animator>().SetBool("qqch", true);
            if (GameObject.FindWithTag("Commande"))
            {
                StopCoroutine(Commande2());
            }
        }
    }
}
