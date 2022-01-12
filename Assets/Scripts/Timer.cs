using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float LeTimer = 60;
    public Text TimerText;
    // Start is called before the first frame update
    void Start()
    {
        TimerText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        LeTimer -= Time.deltaTime;
        TimerText.text = LeTimer.ToString("f0");
    }
}
