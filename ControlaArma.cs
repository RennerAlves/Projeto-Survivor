using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaArma : MonoBehaviour
{
    public GameObject Bala;
    public GameObject CanoDaArma;
    public AudioClip shotSound; 
    private AudioSource audioSource;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>(); 
        audioSource.clip = shotSound; 
        audioSource.playOnAwake = false; 
    }

    void Update()
    {

        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(Bala, CanoDaArma.transform.position, CanoDaArma.transform.rotation);
            audioSource.Play(); 
        }
    }
}
