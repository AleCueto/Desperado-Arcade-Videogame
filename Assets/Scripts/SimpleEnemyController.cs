using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemyController : MonoBehaviour
{
    [SerializeField] private float firstSpeed;
    [SerializeField] private float speed;
    private PlayerMovement player;
    private PointsController pointsController;
    private Rigidbody2D rb2d;
    private Vector3 dir;
    private DificultController difficultController;

    private void Start()
    {

        difficultController = GameObject.FindObjectOfType<DificultController>();
        pointsController = GameObject.FindObjectOfType<PointsController>();
        player = GameObject.FindObjectOfType<PlayerMovement>();
        rb2d = gameObject.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        bool explode = BombController.GetExplode();
        if (explode)
        {
            Die();
        }
        
        Move();

    }


    private void Move()
    {
        if (speed < 0.09)
        {
            speed = firstSpeed + difficultController.GetDifficulty();
        }


        dir = ((gameObject.transform.position - player.transform.position).normalized);
        rb2d.MovePosition(transform.position + dir * speed * -1);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Bullet")
        {
            Die();
        }
    }

    private void Die()
    {
        pointsController.addPoint();
        Destroy(this.gameObject);
    }



}
