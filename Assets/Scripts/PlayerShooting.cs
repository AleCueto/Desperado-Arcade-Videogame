using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [Header("Parameters")]
    [SerializeField] GameObject bullet;
    [SerializeField] GameObject scope;
    [SerializeField] private float cadence;
    private float actualCadence;
    PlayerMovement playerMovement;
    [SerializeField] private bool shooting = false;
    [SerializeField] private AudioSource audioSource;
    PlayerDeathController deathController;

    private void Start()
    {
        deathController = gameObject.GetComponent<PlayerDeathController>();
        audioSource = gameObject.GetComponent<AudioSource>();
        playerMovement = gameObject.GetComponent<PlayerMovement>();
        actualCadence = cadence;
    }

    private void Update()
    {
        if (deathController.GetDead() == false)
        {

            Scoping();
            CadenceController();

            if (Input.GetKey(KeyCode.X) && actualCadence <= 0)
            {

                Vector3 mod1;
                Vector3 mod2;

                //Bullets aside direction depends on where are you loking
                if (playerMovement.GetMov().x > 0 && playerMovement.GetMov().y > 0 || playerMovement.GetMov().x < 0 && playerMovement.GetMov().y < 0)
                {
                    mod1 = new Vector3(-1, 1, 0);
                    mod2 = new Vector3(1, -1, 0);
                }
                else if (playerMovement.GetMov().x > 0 && playerMovement.GetMov().y < 0 || playerMovement.GetMov().x < 0 && playerMovement.GetMov().y > 0)
                {
                    mod1 = new Vector3(1, 1, 0);
                    mod2 = new Vector3(-1, -1, 0);
                }
                else if (playerMovement.GetMov().y == 0)
                {
                    mod1 = Vector3.up;
                    mod2 = Vector3.down;
                }
                else
                {
                    mod1 = Vector3.right;
                    mod2 = Vector3.left;
                }



                Shoot(playerMovement.GetMov());
                Shoot(playerMovement.GetMov() + mod1 * 0.2f);
                Shoot(playerMovement.GetMov() + mod2 * 0.2f);

                actualCadence = cadence;
            }

            if (Input.GetKey(KeyCode.X))
            {
                shooting = true;
            }
            else
            {
                shooting = false;
            }
        }

    }

    private void Shoot(Vector3 direction)
    {
        audioSource.Play();
        GameObject instanciated = Instantiate(bullet, scope.transform.position, Quaternion.identity);
        instanciated.GetComponent<BulletController>().SetDir(direction);
    }

    private void CadenceController()
    {

        if (actualCadence > 0)
        {
            actualCadence -= Time.deltaTime;
        }


    }

    private void Scoping()
    {
        scope.transform.position = playerMovement.transform.position + playerMovement.GetMov() / 1.5f;
    }

    public bool GetShooting()
    {
        return shooting;
    }


}
