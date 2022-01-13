using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Timer : MonoBehaviour
{
    public float LeTimer;
    public TMP_Text TimerText;
    public AudioSource Source;

    public AudioClip horloge;
    // Start is called before the first frame update
    void Start()
    {
        TimerText = GetComponent<TMP_Text>();
        Invoke("DixSecondes", 4.4f);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (LeTimer < 0)
        {
            LeTimer = 0;

            // Inserer le changement de scene ici
            GameManager.LoadScene(2);
        }
        LeTimer -= Time.deltaTime;
        TimerText.text = LeTimer.ToString("f0");
    }

    void DixSecondes()
    { 
        Source.PlayOneShot(horloge, 0.9f);
        print("Yeehaw");
    }
}
