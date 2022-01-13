using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBouffe : MonoBehaviour
{
    public string itemID;

    // Start is called before the first frame update
    void Start()
    {
        itemID = GetComponent<SpriteRenderer>().sprite.name;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
