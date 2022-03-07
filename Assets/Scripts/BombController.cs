using System.Collections;
using System.Collections.Generic;
using UnityEngine.Animations;
using UnityEngine;

public class BombController : MonoBehaviour
{

    private static bool explode;
    private Animator animator;
    private AudioSource audioSource;
    
    private void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        audioSource = gameObject.GetComponent<AudioSource>();
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player"){
            animator.SetBool("Explode", true);
            audioSource.Play();
            explode = true;
            Invoke("SetFalse", 0.5f);
        }
    }


    public static bool GetExplode(){
        return explode;
    }


    private void SetFalse(){
        explode = false;
        Destroy(this.gameObject);
    }
}
