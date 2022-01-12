using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptMouche : MonoBehaviour
{
    public GameObject LaMouche;
    public GameObject LePerso;
    public Rigidbody2D rb;
    // La position X requise avant que la mouche commence à te suivre
    public float XRequisMouche;

    void Start()
    {
        
    }

    void Update()
    {
        // Si la position du personnage en x est superieur à la valeur requise
        if (LePerso.transform.position.x > XRequisMouche) {
            rb.velocity = ((LePerso.transform.position - transform.position) * 2);
        // La mouche commence a te suivre
        }

        else
        {
        // La mouche arrête de te suivre
            rb.velocity = ((LePerso.transform.position - transform.position) * 0);
        }
    }

}
