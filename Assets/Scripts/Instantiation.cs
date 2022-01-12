using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiation : MonoBehaviour
{
    public GameObject mouche;
    public GameObject Serveur;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(mouche);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
