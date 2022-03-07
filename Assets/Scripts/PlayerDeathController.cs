using System.Collections;
using System.Collections.Generic;
using UnityEngine.Animations;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerDeathController : MonoBehaviour
{

    [SerializeField] private GameObject deadBody;
    [SerializeField] AudioSource audioSource;
    Animator animator;
    PointsController pointsController;
    private bool dead;
    CircleCollider2D circleCollider2D;

    private void Start()
    {
        circleCollider2D = gameObject.GetComponent<CircleCollider2D>();
        audioSource = deadBody.GetComponent<AudioSource>();
        animator = gameObject.GetComponent<Animator>();
        pointsController = GameObject.FindObjectOfType<PointsController>();
    }

    private void Update()
    {

    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            StartCoroutine("DeadCorroutine");
        }
    }

    public bool GetDead()
    {
        return dead;
    }

    private IEnumerator DeadCorroutine()
    {
        dead = true;
        pointsController.SaveData(); // Save points
        circleCollider2D.enabled = false;
        animator.SetBool("dead", true);
        Time.timeScale /= 2.5f;
        audioSource.Play();
        yield return new WaitForSecondsRealtime(5f);
        Time.timeScale *= 2.5f;
        SceneManager.LoadScene(0);


    }

}
