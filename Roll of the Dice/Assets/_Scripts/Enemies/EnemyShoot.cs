using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
[RequireComponent(typeof(Animator))]
public class EnemyShoot : MonoBehaviour
{
    ObjectPooler objectPooler;
    AudioSource magicSound;
    Animator animator;
    [SerializeField] private float vida;

    [SerializeField] private GameObject player;

    [SerializeField] private float velocidad;

    [SerializeField] private Transform controladorDisparo;

    [SerializeField] private GameObject bullet;

    NavMeshAgent agent;

    public float daño;

    public float tiempoDisparoRepetición = 1;
    public float tiempoDisparo = 1;

    private void Awake()
    {
        objectPooler = ObjectPooler.Instance;
    }

    public void Start()
    {
        magicSound = GetComponent<AudioSource>(); 
        animator = GetComponent<Animator>();
        InvokeRepeating("DisparoEnemigo", tiempoDisparo + Time.deltaTime, tiempoDisparoRepetición + Time.deltaTime);
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    //IEnumerator RecibiendoDaño()
    //{
    //    gameObject.GetComponent<Renderer>().material.color = Color.white;
    //    yield return new WaitForSeconds(0.08f);
    //    gameObject.GetComponent<Renderer>().material.color = colorNormal;
    //}

    public void Update()
    {
        agent.SetDestination(player.GetComponent<Transform>().position);
    }

    public void TomarDaño(float daño)
    {
        vida -= daño;
        
        //StartCoroutine(RecibiendoDaño());

        if (vida <= 0)
        {
            Muerte();
        }
    }

    IEnumerator Shooting()
    {
        if (gameObject.activeInHierarchy)
        {
            animator.SetTrigger("Shoot");
            yield return new WaitForSeconds(1);
            magicSound.Play();
            objectPooler.SpawnFromPool("Bullet", controladorDisparo.position, controladorDisparo.rotation);
            //Instantiate(bullet, controladorDisparo.position, controladorDisparo.rotation);
            yield break;
        }
        
    }

    public void DisparoEnemigo()
    {
        if (gameObject.activeInHierarchy)
        {
            StartCoroutine(Shooting());
        }
     
    }

    private void Muerte()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<HealthController>().TomarDañoPlayer(daño);
        }
    }
}

