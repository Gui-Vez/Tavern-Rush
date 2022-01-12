using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Client : MonoBehaviour
{
    Rigidbody2D rb;
    public Food foodWanted;
    GameObject spawnPoint;
    Vector2 currentVelocity;
    Animator animator;
    public RuntimeAnimatorController[] clientsAnimators;

    public enum Food
    {
        Pizza,
        Martini,
        Frites
    }

    [SerializeField] bool foodReceived = false;
    [SerializeField] bool arrivedAtTable = false;

    public float clientMoveSpeed;
    
    public GameObject[] tables;

    public int tableWantedIndex;
    [SerializeField] int chosenClientIndex;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        tables = GameObject.FindGameObjectsWithTag("Table");
        spawnPoint = GameObject.FindGameObjectWithTag("SpawnClient");

        //Choose a random table, random food and random client
        tableWantedIndex = Random.Range(0, tables.Length);
        foodWanted = (Food)Random.Range(0, 3);
        chosenClientIndex = Random.Range(0, clientsAnimators.Length);

        animator.runtimeAnimatorController = clientsAnimators[chosenClientIndex];

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
        if (arrivedAtTable == false)
        {
            currentVelocity = (tables[tableWantedIndex].transform.position - transform.position) * clientMoveSpeed;
        }
        else
        {
            currentVelocity = Vector2.zero;
            animator.SetTrigger("ArrivedAtTable");
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

        //Changer l'anim
        animator.SetTrigger("QuittingTable");
        currentVelocity = (spawnPoint.transform.position - transform.position) * clientMoveSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "SpawnClient" && foodReceived)
        {
            ClientSpawner.totalWaitingClients--;
            Destroy(gameObject);
        }

        if (collision.gameObject == tables[tableWantedIndex])
        {
            //Arrived at table
            arrivedAtTable = true;
            print("arrivedAtTable");
        }
    }


}
