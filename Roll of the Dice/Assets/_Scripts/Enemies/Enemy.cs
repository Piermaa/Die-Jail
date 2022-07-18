using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float vida;

    [SerializeField] private GameObject player;

    NavMeshAgent agent;

    public float da�o;

    public void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void Update()
    {
        agent.SetDestination(player.GetComponent<Transform>().position);
    }

    //IEnumerator RecibiendoDa�o()
    //{
    //    gameObject.GetComponent<Renderer>().material.color = Color.white;
    //    yield return new WaitForSeconds(0.08f);
    //    gameObject.GetComponent<Renderer>().material.color = colorNormal;
    //}

    public void TomarDa�o(float da�o)
    {
        vida -= da�o;

        //StartCoroutine(RecibiendoDa�o());

        if (vida <= 0)
        {
            Muerte();
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
            other.GetComponent<HealthController>().TomarDa�oPlayer(da�o);
        }
    }
}