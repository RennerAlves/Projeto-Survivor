using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaZumbi : MonoBehaviour
{
    public GameObject Jogador;
    public float velocidade = 5;

    // Start is called before the first frame update
    void Start()
    {
        Jogador = GameObject.FindWithTag("Jogador");
        int geraTipoZumbi = Random.Range(1, 28);
        transform.GetChild(geraTipoZumbi).gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update() 
    {
        
    }

    void FixedUpdate()
    {
        // Movimentação do personagem por segundo

        float distancia = Vector3.Distance(transform.position, Jogador.transform.position);

        // rotacione sempre em direção ao personagem
        Vector3 direcao = Jogador.transform.position - transform.position;
        Quaternion novaRotacao = Quaternion.LookRotation(direcao);
        GetComponent<Rigidbody>().MoveRotation(novaRotacao);

        if (distancia > 2.5)
        {
            // movimente!
            
            GetComponent<Rigidbody>().MovePosition
                (GetComponent<Rigidbody>().position +
                direcao.normalized * velocidade * Time.deltaTime);

            GetComponent<Animator>().SetBool("Atacando", false);

        }
        else
        {
            GetComponent<Animator>().SetBool("Atacando", true);
        }

    }

    void AtacaJogador()
    {
        Time.timeScale = 0;
        Jogador.GetComponent<NewBehaviourScript>().TextoGameOver.SetActive(true);
        Jogador.GetComponent<NewBehaviourScript>().Vivo = false;
    }
}
