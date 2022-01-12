using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flaque : MonoBehaviour
{
    public GameObject flaque;
    public AudioClip sonFlaque;
    public int compteurFlaque = 0;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnFlaque());
    }

    IEnumerator SpawnFlaque()
    {
        while (compteurFlaque < 1)
        {
            // Faire respirer la coroutine à chaque 10 secondes
            yield return new WaitForSeconds(2f);
            
            //Génération d'un ennemi au hasard
            GameObject instanceFlaque = Instantiate(flaque, flaque.transform.position, flaque.transform.rotation);
            compteurFlaque++;
            GetComponent<AudioSource>().PlayOneShot(sonFlaque, 5f);
            instanceFlaque.SetActive(true);
            StopCoroutine(SpawnFlaque());
            
            //GetComponent<Animator>().SetBool("qqch", true);
        }
    }
}
