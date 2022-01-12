using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Client : MonoBehaviour
{
    Rigidbody2D rb;
    GameObject spawnPoint;
    Vector2 currentVelocity;
    Animator animator;
    Animator bubbleAnimator;

    public Food foodWanted;
    public RuntimeAnimatorController[] clientsAnimators;

    public enum Food
    {
        Pizza,
        Martini,
        Frites
    }

    public Sprite[] foodSprites;
    GameObject foodWantedClone;
    public GameObject foodWantedPrefab;

    public bool foodReceived = false;
    [SerializeField] bool arrivedAtTable = false;
    bool quittingTable = false;

    public float clientMoveSpeed;
    
    GameObject[] tables;

    public int tableWantedIndex;
    [SerializeField] int chosenClientIndex;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        bubbleAnimator = transform.GetChild(0).GetComponent<Animator>();

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
            if (foodReceived == false)
            {
                currentVelocity = Vector2.zero;
                animator.SetTrigger("ArrivedAtTable");
                bubbleAnimator.SetTrigger("ArrivedAtTable");


                if (tables[tableWantedIndex].transform.childCount > 0)
                {
                    if (tables[tableWantedIndex].transform.GetChild(0).gameObject.name == foodWanted.ToString())
                    {
                        print("foodReceived !");
                        foodReceived = true;
                    }
                    else
                    {
                        //Le client part, fâché !
                    }
                }
                
            }
            
        }

        if (foodReceived && quittingTable == false)
        {
            quittingTable = true;
            print("callQuitRoutine");
            //Attendre un peu à la table, puis partir
            StartCoroutine(QuitRoutine());

        }

        rb.velocity = currentVelocity;
        
    }

    IEnumerator QuitRoutine()
    {
        Destroy(foodWantedClone);
        bubbleAnimator.SetTrigger("QuittingTable");
        yield return new WaitForSeconds(1f);

        //Changer l'anim
        animator.SetTrigger("QuittingTable");
        currentVelocity = (spawnPoint.transform.position - transform.position) * clientMoveSpeed;
        tables[tableWantedIndex].layer = 6;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "SpawnClient" && foodReceived)
        {
            
            Destroy(gameObject);
            //spawnPoint.GetComponent<ClientSpawner>().canSpawnClient = true;
            ClientSpawner.totalWaitingClients--;
            
        }

        if (collision.gameObject == tables[tableWantedIndex])
        {
            //Arrived at table
            arrivedAtTable = true;
            
            //Créer l'item bouffe dans la bulle, etc
            foodWantedClone = Instantiate(foodWantedPrefab, Vector2.zero, Quaternion.identity, bubbleAnimator.gameObject.transform);
            foodWantedClone.GetComponent<SpriteRenderer>().sprite = foodSprites[(int)foodWanted];
            foodWantedClone.transform.localPosition = Vector2.zero;
            foodWantedClone.transform.localScale = new Vector2(0.7f, 0.7f);
            //print("arrivedAtTable");
        }
    }


}
