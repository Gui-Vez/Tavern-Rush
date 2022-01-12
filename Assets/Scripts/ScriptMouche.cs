using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptMouche : MonoBehaviour
{
    public GameObject LaMouche;
    public GameObject LePerso;

    void Start()
    {
        
    }

    void Update()
    {
        if (LePerso.transform.position.x > 10)
        {
            StartCoroutine(moveToX(LaMouche.transform, LePerso.transform.position, 0.5f));
        }

    }


    IEnumerator moveToX(Transform fromPosition, Vector3 toPosition, float duration)
    {

        float counter = 0;

        //Get the current position of the object to be moved
        Vector3 startPos = fromPosition.position;

        while (counter < duration)
        {
            counter += Time.deltaTime;
            fromPosition.position = Vector3.Lerp(startPos, toPosition, counter / duration);
            yield return null;
        }
    }
}
