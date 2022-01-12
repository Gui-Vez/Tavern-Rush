using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Client : MonoBehaviour
{
    Rigidbody2D rb;
    Food foodWanted;
    GameObject spawnPoint;
    Vector2 currentVelocity;

    public enum Food
    {
        Pizza,
        Martini,
        Sushi
    }

    public bool foodReceived = false;

    public float clientMoveSpeed;
    
    public GameObject[] tables;

    public int tableWantedIndex;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        tables = GameObject.FindGameObjectsWithTag("Table");
        spawnPoint = GameObject.FindGameObjectWithTag("SpawnClient");

        //Choose a random table and a random food
        tableWantedIndex = Random.Range(0, tables.Length);
        foodWanted = (Food)Random.Range(0, 2);

        //Layer 6 = Table Libre
        //Layer 7 = Table Occupée
        
        while (tables[tableWantedIndex].layer == 7)
        {
            tableWantedIndex = Random.Range(0, tables.Length);
        }
        

        tables[tableWantedIndex].layer = 7;

    }

    // Update is called once per frame
    void Update()
    {
        //Le client se dirige vers la table choisie
        if (transform.position != tables[tableWantedIndex].transform.position && foodReceived == false)
        {
            currentVelocity = Vector3.Normalize(tables[tableWantedIndex].transform.position - transform.position) * clientMoveSpeed;
        }

        if (foodReceived)
        {
            //Attendre un peu à la table, puis partir
            StartCoroutine(QuitRoutine());

        }

        rb.velocity = currentVelocity;
    }

    IEnumerator QuitRoutine()
    {
        yield return new WaitForSeconds(1f);

        currentVelocity = Vector3.Normalize(spawnPoint.transform.position - transform.position) * (clientMoveSpeed/2);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "SpawnClient" && foodReceived)
        {
            ClientSpawner.totalWaitingClients--;
            Destroy(gameObject);
        }
    }


}
