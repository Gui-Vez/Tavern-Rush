using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public float LeTimer;
    public Text TimerText;
    // Start is called before the first frame update
    void Start()
    {
        TimerText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (LeTimer < 0)
        {
            LeTimer = 0;
            // Inserer le changement de scene ici
            // SceneManager.LoadScene("");
        }
        LeTimer -= Time.deltaTime;
        TimerText.text = LeTimer.ToString("f0");
    }
}
