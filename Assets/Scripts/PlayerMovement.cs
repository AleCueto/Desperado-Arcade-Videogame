using System.Collections;
using System.Collections.Generic;
using UnityEngine.Animations;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Parameters")]
    [SerializeField] private float speed;
    [SerializeField] private float actualSpeed;
    [SerializeField] private GameObject legs;
    private Animator legsAnim;
    [SerializeField] private GameObject trunk;
    private Animator trunkAnim;
    [SerializeField] private GameObject arms;
    private Animator armsAnim;


    private float bootSpeed = 0;

    private PlayerDeathController deathController;
    private PlayerShooting shoot;
    private Rigidbody2D rb2d;
    private Vector3 mov;
    private Vector3 staticMov; //Mov just update when you move
    private float movx, movy;


    private void Start(){
        actualSpeed = speed;
        deathController = gameObject.GetComponent<PlayerDeathController>();
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        legsAnim = legs.GetComponent<Animator>();
        trunkAnim = trunk.GetComponent<Animator>();
        armsAnim = arms.GetComponent<Animator>();
        shoot = gameObject.GetComponent<PlayerShooting>();
    }

    private void Update(){
        if(deathController.GetDead() == false){
            Movement();
            Animate();
        }
    }

    private void Movement(){

        if(shoot.GetShooting() == true){
            actualSpeed = speed / 2f;
        } else {
            actualSpeed = speed;
        }

        actualSpeed = actualSpeed + bootSpeed;

        movx = Input.GetAxisRaw("Horizontal");
        movy = Input.GetAxisRaw("Vertical");
        mov = new Vector3(movx, movy);


        rb2d.MovePosition(transform.position + mov * actualSpeed);
    }


    private void Animate(){

        if(mov != Vector3.zero){
            staticMov = mov;
            legsAnim.SetBool("Running", true);
            armsAnim.SetFloat("movx", movx);
            armsAnim.SetFloat("movy", movy);
        } else{
            legsAnim.SetBool("Running", false);
        }

        if(movy != 0){
            trunkAnim.SetFloat("movy", movy);
        }

    }

    public Vector3 GetMov(){
        return staticMov;
    }


    private IEnumerator bootUse(){
        bootSpeed = 0.05f;
        yield return new WaitForSeconds(3);
        bootSpeed = 0;
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "boot"){
            StartCoroutine("bootUse");
            Destroy(other.gameObject);
        }
    }

}
