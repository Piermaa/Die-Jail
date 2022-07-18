using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTime : MonoBehaviour,IPooledObject
{
    [SerializeField] private float tiempoDeVida;

    public void OnObjectSpawn()
    {
        tiempoDeVida = 10;
    }

    private void Update()
    {
        tiempoDeVida -= Time.deltaTime;

        if (tiempoDeVida<0)
        {
            this.gameObject.SetActive(false);
        }
    }
}
