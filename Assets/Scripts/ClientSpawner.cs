using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientSpawner : MonoBehaviour
{
    public GameObject clientPrefab;
    public static int totalWaitingClients = 0;
    public static int nbOfClientsServed = 0;
    public bool canSpawnClient = false;

    public IEnumerator spawnCoroutine;
    //Avoir l'array table qui est dans client ici aussi

    public GameObject RefSons;

    public void Awake()
    {
        StartCoroutine("SpawnClient");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //print(totalWaitingClients);

        if (totalWaitingClients == 4 && canSpawnClient == false)
        {
            canSpawnClient = true;
            //print("stopped spawning");
            StopAllCoroutines();
        }

    }

    public IEnumerator SpawnClient()
    {
        //Quand il y a 4 clients ou plus de spawn, arr�ter de spawn, MAIS recommencer d�s qu'un client ou plus
        //est d�truit

        //print("Calling function");
        Instantiate(clientPrefab, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
        totalWaitingClients++;

        float time = Random.Range(1.5f, 2.5f);

        yield return new WaitForSeconds(time);

        StartCoroutine(SpawnClient());

        RefSons.GetComponent<GestionSonoreAmbiance>().JouerSons("Client");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Client" && collision.gameObject.GetComponent<Client>().foodReceived)
        {
            nbOfClientsServed++;

            if (nbOfClientsServed % 2  == 0)
            {
                StartCoroutine(SpawnClient());
                canSpawnClient = false;

            }
           
        }
    }
}
