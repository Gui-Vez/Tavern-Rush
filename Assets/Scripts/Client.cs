using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Client : MonoBehaviour
{
    Rigidbody2D rb;

    public enum Food
    {
        Pizza,
        Martini,
        Sushi
    }

    public Food foodWanted;
    GameObject[] tables;

    int tableWantedIndex;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        tables = GameObject.FindGameObjectsWithTag("Table");

        tableWantedIndex = Random.Range(0, tables.Length);

    }

    // Update is called once per frame
    void Update()
    {
        //Le client se dirige vers la table choisie
        if (transform.position != tables[tableWantedIndex].transform.position)
        {
            rb.MovePosition(tables[tableWantedIndex].transform.position);

        }

    }
}
