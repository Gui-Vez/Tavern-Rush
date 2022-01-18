using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public static int totalWaitingClients = 0;
    public static int nbOfClientsServed = 0;
    public static int nbOfOrdersDeliveredSuccessfully = 0;
    public int nbOfOrdersToWin;

    
    TMP_Text scoreText;
    TMP_Text winText;
    TMP_Text loseText;
    AudioSource musicEnd;
    Button MenuPrincipal;
    Button boutonQuit;

    public AudioClip musicWin;
    public AudioClip musicLose;

    Animator serveurAnim;

    Scene currentScene;

    static GameManager current;
    
     private void Awake()
     {
        /*
        if (GameObject.FindGameObjectWithTag("GameController") && GameObject.FindGameObjectWithTag("GameController") != this.gameObject)
            Destroy(GameObject.FindGameObjectWithTag("GameController"));
            */


         if (current != null && current != this)
         {
                //Destroy(gameObject);
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

                if (GameObject.FindGameObjectWithTag("BoutonQuit"))
                {
                    boutonQuit = GameObject.FindGameObjectWithTag("BoutonQuit").GetComponent<Button>();

                    boutonQuit.onClick.AddListener(() => QuitApp());
                }

                    
                    


                    //Reset les variables stathicc
                    totalWaitingClients = 0;
                    nbOfClientsServed = 0;
                    nbOfOrdersDeliveredSuccessfully = 0;
                
                

                break;

            case 1:

                
                break;

            case 2:

                if (scoreText == null)
                {
                    //Dude, c'est un fuckin' tag, oublie pas demain
                    scoreText = GameObject.FindGameObjectWithTag("Score").GetComponent<TMP_Text>();
                    musicEnd = GameObject.FindGameObjectWithTag("MusicEnd").GetComponent<AudioSource>();
                    MenuPrincipal = GameObject.FindGameObjectWithTag("ButtonMenu").GetComponent<Button>();
                    winText = GameObject.Find("WinText").GetComponent<TMP_Text>();
                    loseText = GameObject.Find("LoseText").GetComponent<TMP_Text>();
                    serveurAnim = GameObject.Find("Serveur").GetComponent<Animator>();

                    MenuPrincipal.onClick.AddListener(() => LoadScene(0));

                    scoreText.text += nbOfOrdersDeliveredSuccessfully.ToString();
                     
                    if (nbOfOrdersDeliveredSuccessfully >= nbOfOrdersToWin)
                    {
                        //Activate Win Text, Win Anim
                        winText.enabled = true;
                        serveurAnim.SetTrigger("Win");

                        musicEnd.PlayOneShot(musicWin);
                    }
                    else
                    {
                        //Activate Lose Text, Lose Anim
                        loseText.enabled = true;
                        serveurAnim.SetTrigger("Lose");

                        musicEnd.PlayOneShot(musicLose);
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

    public void QuitApp()
    {
        Application.Quit();
    }
}
