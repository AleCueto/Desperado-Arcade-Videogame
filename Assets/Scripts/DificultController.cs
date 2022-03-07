using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DificultController : MonoBehaviour
{
    [SerializeField] private float difficulty;
    private float timer;

    void Start()
    {
        
    }

    void Update()
    {
        IncreaseDifficulty();
    }

    private void IncreaseDifficulty(){
        timer += Time.deltaTime;
        difficulty = timer/10000;
    }



    public float GetDifficulty(){
        return difficulty;
    }
}
