using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float lifeTime;
    private Rigidbody2D rb2d;
    private Vector3 dir;

    private void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();   
    }

    private void Update()
    {   
        Death();
        Movement();
    }

    private void Movement(){
        rb2d.MovePosition(transform.position + dir * speed);
    }

    public void SetDir(Vector3 direction){
        dir = direction;
    }

    private void Death(){
        lifeTime -= Time.deltaTime;
        if(lifeTime <= 0){
            Destroy(this.gameObject);
        }
    }
}
