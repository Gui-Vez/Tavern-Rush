using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientSpawner : MonoBehaviour
{
    public GameObject clientPrefab;
    

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
        Instantiate(clientPrefab, transform.position, Quaternion.identity);

        yield return new WaitForSeconds(Random.Range(1.5f,2.5f));

        StartCoroutine(SpawnClient());
    }
}
