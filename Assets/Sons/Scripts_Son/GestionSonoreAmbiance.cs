using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionSonoreAmbiance : MonoBehaviour
{
    private AudioSource Audio;

    public AudioClip client;

    //bool peutJouerSFX = true;

    void Start()
    {
        // Raccourci du AudioSource
        Audio = GetComponent<AudioSource>();
    }


    void Update()
    {
        //GetComponent<AudioSource>().volume = 
        
        /*
        if (Input.GetKey(KeyCode.X))
        {
            StartCoroutine(AttendreSFX("Client"));
        }
        */
    }

    public void JouerSons(string SFX)
    {
        // Selon l'effet sonore,
        switch (SFX)
        {
            case "Client": Audio.PlayOneShot(client, 1.00f); break;
        }
    }

    /*
    public IEnumerator AttendreSFX(string SFX)
    {
        if (peutJouerSFX)
        {
            peutJouerSFX = false;

            JouerSons(SFX);

            yield return new WaitForSeconds(2);

            peutJouerSFX = true;
        }

        yield return null;
    }
    */
}
