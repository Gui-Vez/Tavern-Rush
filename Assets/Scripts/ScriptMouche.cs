using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptMouche : MonoBehaviour
{
    public GameObject LaMouche;
    public GameObject LeServeur;
    public Rigidbody2D rb;
    private SpriteRenderer SpriteMouche;
    // La position X requise avant que la mouche commence à te suivre
    public float XRequisMouche;

    void Start()
    {
        SpriteMouche = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Change de regard en fonction du deplacement en X
        if (rb.velocity.x > 0)
        {
            SpriteMouche.flipX = true;
        }

        if (rb.velocity.x < 0)
        {
            SpriteMouche.flipX = false;
        }

        // Si la position du personnage en x est superieur à la valeur requise
        if (LeServeur.transform.position.x > XRequisMouche) {
            rb.velocity = ((LeServeur.transform.position - transform.position) * 2);
            // La mouche commence a te suivre
        }

        else
        {
        // La mouche arrête de te suivre
            rb.velocity = ((LeServeur.transform.position - transform.position) * 0);
        }
    }

}
