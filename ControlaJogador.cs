using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{

    public float velocidade = 10;
    Vector3 direcao;
    public LayerMask MascaraChao;
    public GameObject TextoGameOver;
    public bool Vivo = true;


    void Start()
    {
        Time.timeScale = 1;
    }


    // Update is called once per frame
    void Update()
    {

        // Inputs do Jogador - Guardando teclas apertadas
        float eixoX = Input.GetAxis("Horizontal");
        float eixoZ = Input.GetAxis("Vertical");

        direcao = new Vector3(eixoX, 0, eixoZ);


        // Animações do personagem
        if (direcao != Vector3.zero)
        {
            GetComponent<Animator>().SetBool("Movendo", true);
        } else
        {
            GetComponent<Animator>().SetBool("Movendo", false);
        }


        if(Vivo == false)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                SceneManager.LoadScene("Game - Fase 1");
            }
        }
    }

    
    void FixedUpdate()
    {
        // Movimentação do personagem por segundo
        GetComponent<Rigidbody>().MovePosition
            (GetComponent<Rigidbody>().position +
            (direcao * velocidade * Time.deltaTime));

        //direcao * velocidade * Time.deltaTime é a direção do movimento, para onde queremos ir
        //GetComponent<Rigidbody>().position pega a posição atual do componente.


        Ray raio = Camera.main.ScreenPointToRay(Input.mousePosition); 
        Debug.DrawRay(raio.origin, raio.direction * 100, Color.red);

        RaycastHit impacto;

        if(Physics.Raycast(raio, out impacto, 100, MascaraChao))
        {
            Vector3 posicaoMiraDoJogador = impacto.point - transform.position;
            posicaoMiraDoJogador.y = transform.position.y;
            Quaternion rotacao = Quaternion.LookRotation(posicaoMiraDoJogador);
            GetComponent<Rigidbody>().MoveRotation(rotacao);
        }

        
    }
}
 