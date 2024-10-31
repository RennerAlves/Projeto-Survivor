using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeradorDeZumbi : MonoBehaviour
{

    float contadorTempo = 0;
    public float TempoGerarZumbi = 1;

    public GameObject Zumbi;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        contadorTempo += Time.deltaTime;
        if (contadorTempo >= TempoGerarZumbi)
        {
            Instantiate(Zumbi, transform.position, transform.rotation);
            contadorTempo = 0;
        }
       
        
    }
}
