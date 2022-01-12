using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionSonoreAmbiance : MonoBehaviour
{
    private AudioSource Audio;
    public AudioSource AudioFoule;

    public AudioClip client;
    public AudioClip cloche;
    public AudioClip flaque;
    public AudioClip livraison;
    public AudioClip ramassage;


    void Start()
    {
        // Raccourci du AudioSource
        Audio = GetComponent<AudioSource>();
    }


    void Update()
    {
        // Si le volume est inférieur à 0.25,
        if (AudioFoule.volume < 0.25f)
        {
            // Augmenter progressivement le volume
            AudioFoule.volume += 0.00075f;
        }
    }

    public void JouerSons(string SFX)
    {
        // Selon l'effet sonore,
        switch (SFX)
        {
            // Jouer cet effet sonore
            case "Client"   : Audio.PlayOneShot(client, 0.25f);    break;
            case "Cloche"   : Audio.PlayOneShot(cloche, 0.15f);    break;

            case "Livraison": Audio.PlayOneShot(livraison, 0.50f); break;
            case "Ramassage": Audio.PlayOneShot(ramassage, 0.75f); break;

            case "Flaque"   : Audio.PlayOneShot(flaque, 1.00f);    break;
        }
    }
}
