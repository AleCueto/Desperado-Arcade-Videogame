using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    
    [SerializeField] private GameObject instantiable;
    [SerializeField] private float timeToSpawn;
    [SerializeField] private float rangeToSpawn;
    private float counter;

    void Start()
    {
        counter = timeToSpawn;
    }

    void Update()
    {
        counter -= Time.deltaTime;

        if(counter <= 0){
            Spawn();
            counter = timeToSpawn;
        }
    }


    void Spawn(){
        Instantiate(instantiable, transform.position + new Vector3(Random.Range(0,rangeToSpawn), Random.Range(0,rangeToSpawn)), Quaternion.identity);
    }

}
