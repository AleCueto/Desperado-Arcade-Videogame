using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PointsController : MonoBehaviour
{

    [SerializeField] private Text counter = null;
    private PlayerMovement player;
    private float firstPos;
    private int points = 0;
    private string pointsEarned;

    private void Awake(){
        if(SceneManager.GetActiveScene().name == "Title"){
            LoadData();
        } else{
            points = 0;
        }

    }

    private void Start()
    {
        player = GameObject.FindObjectOfType<PlayerMovement>();
    }

    private void Update()
    {
        Size();
    }

    public void addPoint(){
        points ++;
    }


    private void Size(){
        //int points =  (int)(player.transform.position.y - firstPos);
        if(counter != null){
            counter.text =  points.ToString() + " frogs";   
        }
    }

    public void SaveData(){
        PlayerPrefs.SetInt(pointsEarned, points);
    }

    public void LoadData(){
        points = PlayerPrefs.GetInt(pointsEarned, 0);
    }

    public string GetPoints(){
        return points.ToString();
    }
}
