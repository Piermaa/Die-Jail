using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Boss : MonoBehaviour
{
    ObjectPooler objectPooler;
    Animator animator;
    GameObject player;
    [SerializeField] GameObject body;
    [SerializeField] GameObject bullet;

    public bool laserPlay;

    float laserCooldown = 5;
    float laserTime;

    [SerializeField] AudioSource laserSound;
    [SerializeField] AudioSource featherSound;
    [SerializeField] AudioSource meleeAttackSound;

    [SerializeField] ParticleSystem laser;
    [SerializeField] Transform laserOrigin;
    [SerializeField] Transform leftOrigin;
    [SerializeField] Transform rightOrigin;
    float shootCooldown;

    NavMeshAgent agent;
    private void Awake()
    {
        objectPooler = ObjectPooler.Instance;
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void Update()
    {
        shootCooldown -= Time.deltaTime;


    
       

        agent.SetDestination(player.transform.position);


        if (shootCooldown < 0)
        {
           
            shootCooldown = 0.2f;
            featherSound.Play();
            objectPooler.SpawnFromPool("Feather", leftOrigin.position, leftOrigin.rotation);
            objectPooler.SpawnFromPool("Feather", leftOrigin.position, leftOrigin.rotation);
    
     
        }



        laserTime -= Time.deltaTime;

        if (laserTime<0)
        {
            laserTime = laserCooldown;
            animator.SetTrigger("Laser");
            if (!laserSound.isPlaying)
            {
                laserSound.Play();
            }
        }
        if (laserPlay)
        {
            laser.Play();
        }
        else
        {
            body.transform.LookAt(player.transform);
        }
      
    }

 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ODST();
        }
    }

    private void ODST()
    {
        animator.SetTrigger("MeleeAttack");
        meleeAttackSound.Play();
    }

    private void OnDestroy()
    {
       ChangeScenes scene= FindObjectOfType<ChangeScenes>();

        scene.ReturnToMainMenu();

    }
}
