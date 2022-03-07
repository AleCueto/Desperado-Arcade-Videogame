using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private Button buttonStart, buttonTutorial;
    [SerializeField] private Text pointText = null;
    private PointsController pointsController;
    private string points = "You Killed ";



    private void Start()
    {
        buttonStart.onClick.AddListener(LoadMain);
        buttonTutorial.onClick.AddListener(LoadTutorial);
        pointsController = GameObject.FindObjectOfType<PointsController>();
        points += pointsController.GetPoints();
        pointText.text += points + " frogs";

    }

    private void Update()
    {

    }

    private void LoadMain()
    {
        SceneManager.LoadScene(2);
    }

    private void LoadTutorial()
    {
        SceneManager.LoadScene(1);
    }

}
