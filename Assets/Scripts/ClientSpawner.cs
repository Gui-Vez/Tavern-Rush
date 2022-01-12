using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientSpawner : MonoBehaviour
{
    public GameObject clientPrefab;
    public static int totalWaitingClients = 0;

    public void Awake()
    {
        StartCoroutine(SpawnClient());
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnClient()
    {
        if (totalWaitingClients < 4)
        {
            Instantiate(clientPrefab, transform.position, Quaternion.identity);
            totalWaitingClients++;

            yield return new WaitForSeconds(Random.Range(1.5f, 2.5f));

            StartCoroutine(SpawnClient());
        }

       
    }
}
