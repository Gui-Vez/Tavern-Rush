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

    TMP_Text endText;

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

                if (endText == null)
                {
                    endText = GameObject.FindGameObjectWithTag("Score").GetComponent<TMP_Text>();
                    endText.text += nbOfOrdersDeliveredSuccessfully.ToString();
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
}
