using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class TutorialController : MonoBehaviour
{
    [SerializeField] private GameObject upArrow, downArrow, leftArrow, rightArrow, cross, space;
    private AudioSource audioSource;

    private void Start()
    {
        space.SetActive(false);
        audioSource = gameObject.GetComponent<AudioSource>();

    }

    private void Update()
    {

        Disapear();

        if (upArrow.activeInHierarchy == false && downArrow.activeInHierarchy == false && leftArrow.activeInHierarchy == false && rightArrow.activeInHierarchy == false && cross.activeInHierarchy == false)
        {
            Space();
        }

    }

    private void Disapear()
    {

        if (Input.GetKeyDown(KeyCode.RightArrow) && rightArrow.activeInHierarchy == true)
        {
            rightArrow.SetActive(false);
            audioSource.Play();
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow) && leftArrow.activeInHierarchy == true)
        {
            leftArrow.SetActive(false);
            audioSource.Play();
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && upArrow.activeInHierarchy == true)
        {
            upArrow.SetActive(false);
            audioSource.Play();
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) && downArrow.activeInHierarchy == true)
        {
            downArrow.SetActive(false);
            audioSource.Play();
        }

        if (Input.GetKeyDown(KeyCode.X) && cross.activeInHierarchy == true)
        {
            cross.SetActive(false);
            audioSource.Play();
        }

    }

    private void Space()
    {
        space.SetActive(true);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            audioSource.Play();
            SceneManager.LoadScene(2);
        }
    }



}
