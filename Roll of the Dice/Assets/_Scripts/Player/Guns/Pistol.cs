using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : MonoBehaviour
{
    public GameObject diceParticles;
    public GameObject explodeParticles;
    public GameObject enemyParticles;
    public GameObject heavyParticles;
    public GameObject shootParticles;


    float shootcd=0.1f;
    float shoottime;
    AudioSource shootSound;

    public float damage = 10f;
    public float range = 100f;

    public Camera fpsCam;
    public ParticleSystem muzzleFlash;


    private void Start()
    {
        shootSound = GetComponent<AudioSource>();   
    }
    void Update()
    {
        shoottime -= Time.deltaTime;
        //if (Input.GetButtonDown("Fire1"))
        //{
        //    Shoot();
        //}
        if (Input.GetButton("Fire1"))
        {
            if (shoottime<0)
            {
                shoottime = shootcd;
                Shoot();
            }

        }
    }

    void Shoot()
    {
        shootSound.Play();
        if (!muzzleFlash.isPlaying)
        {
            muzzleFlash.Play();

        }

        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.position);


        
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit screenHit;

                if (Physics.Raycast(ray, out screenHit))
                {
                    Debug.Log(screenHit.point);
                }

                Vector3 dir = hit.transform.position - transform.position;

                Target target = hit.transform.GetComponent<Target>();

                if (target != null)
                {
                    print(hit.transform.name);
                    switch (hit.transform.name)
                    {
                        case "EnemyExplode(Clone)":
                            Instantiate(explodeParticles, hit.transform.position, Quaternion.Euler(dir));
                            break;
                        case "Enemy(Clone)":
                            Instantiate(enemyParticles, hit.transform.position, Quaternion.Euler(dir));
                            break;
                        case "EnemyHeavy(Clone)":
                            Instantiate(heavyParticles, hit.transform.position, Quaternion.Euler(dir));
                            break;
                        case "EnemyShoot(Clone)":
                            Instantiate(shootParticles, hit.transform.position, Quaternion.Euler(dir));
                            break;
                    case "pajaritoconfondo":
                        Instantiate(shootParticles, hit.transform.position, Quaternion.Euler(dir));
                        break;
                }

                 
                    target.TakeDamage(damage);
                }
                else
                {
                    //Instantiate(diceParticles, screenHit.transform.position, Quaternion.Euler(dir));
                }
            
        }
    }
}
