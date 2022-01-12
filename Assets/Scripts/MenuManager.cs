using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MenuManager : MonoBehaviour
{
    public GameObject[] panels;
    public Button[] buttons;

    // Start is called before the first frame update
    void Start()
    {
        buttons[0].onClick.AddListener(() => ManagePanels(panels[0], panels[1]));
        buttons[1].onClick.AddListener(() => GameManager.LoadScene(1));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ManagePanels(GameObject from, GameObject to)
    {
        from.SetActive(false);
        to.SetActive(true);
    }
}
