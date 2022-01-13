using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{

    public static int totalWaitingClients = 0;
    public static int nbOfClientsServed = 0;
    public static int nbOfOrdersDeliveredSuccessfully = 0;
    public int nbOfOrdersToWin;

    TMP_Text scoreText;
    TMP_Text winText;
    TMP_Text loseText;

    Animator serveurAnim;

    Scene currentScene;

    static GameManager current;
    
     private void Awake()
     {
         if (GameObject.FindGameObjectWithTag("GameController") && GameObject.FindGameObjectWithTag("GameController") != this.gameObject) Destroy(GameObject.FindGameObjectWithTag("GameController"));


         if (current != null && current != this)
         {
                Destroy(gameObject);
                return;
         }

         current = this;

         DontDestroyOnLoad(gameObject);

     }
        
    

    // Update is called once per frame
    void Update()
    {
         currentScene = SceneManager.GetActiveScene();


        switch (currentScene.buildIndex)
        {
            case 0:
                break;

            case 1:
                break;

            case 2:

                if (scoreText == null)
                {
                    scoreText = GameObject.FindGameObjectWithTag("Score").GetComponent<TMP_Text>();
                    winText = GameObject.Find("WinText").GetComponent<TMP_Text>();
                    loseText = GameObject.Find("LoseText").GetComponent<TMP_Text>();
                    serveurAnim = GameObject.Find("Serveur").GetComponent<Animator>();

                    scoreText.text += nbOfOrdersDeliveredSuccessfully.ToString();
                     
                    if (nbOfOrdersDeliveredSuccessfully > 10)
                    {
                        //Activate Win Text, Win Anim
                        winText.enabled = true;
                        serveurAnim.SetTrigger("Win");
                    }
                    else
                    {
                        //Activate Lose Text, Lose Anim
                        loseText.enabled = true;
                        serveurAnim.SetTrigger("Lose");
                    }
                }
                
                break;

            default:
                break;
        }
        
    }

    public static void LoadScene(int buildIndex)
    {
        SceneManager.LoadScene(buildIndex);

    }

    public void Quit()
    {
        Application.Quit();
    }
}
