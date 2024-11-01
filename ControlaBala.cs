using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaBala : MonoBehaviour
{
    public float Velocidade = 20;

    void Start()
    {
    }

    void Update()
    {
    }

    void FixedUpdate()
    {
        GetComponent<Rigidbody>().MovePosition
            (GetComponent<Rigidbody>().position + transform.forward * Velocidade * Time.deltaTime);
    }

    void OnTriggerEnter(Collider objetoDeColisao)
    {
        if (objetoDeColisao.CompareTag("Inimigo"))
        {
            Destroy(objetoDeColisao.gameObject); 
        }

        Destroy(gameObject);
    }
}
