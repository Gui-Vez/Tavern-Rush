using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flaque : MonoBehaviour
{
    public GameObject[] SpawnersFlaques;
    public int compteurFlaque = 0;

    public GameObject RefSons;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Commande());
    }

    IEnumerator Commande()
    {
        while (compteurFlaque < 4)
        {
            // Faire respirer la coroutine à chaque 10 secondes
            yield return new WaitForSeconds(2f);
            
            //Génération d'un ennemi au hasard
            int FlaqueAuHasard = Random.Range(0, SpawnersFlaques.Length);
            GameObject instanceFlaque = Instantiate(SpawnersFlaques[FlaqueAuHasard], SpawnersFlaques[FlaqueAuHasard].transform.position, SpawnersFlaques[FlaqueAuHasard].transform.rotation);
            compteurFlaque++;
            RefSons.GetComponent<GestionSonoreAmbiance>().JouerSons("Flaque");
            instanceFlaque.SetActive(true);
            StopCoroutine(Commande());
            
            //GetComponent<Animator>().SetBool("qqch", true);
        }
    }
}
