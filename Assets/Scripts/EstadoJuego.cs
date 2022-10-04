using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EstadoJuego : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(RevisarCaja());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MostrarGato(){
        AbrirCaja();
        if (Random.Range(0, 2) == 0){
            GatoVivo();
        } else {
            GatoMuerto();
        }
        StartCoroutine(ReiniciarCaja());
    }

    IEnumerator ReiniciarCaja(){
        yield return new WaitForSeconds(5);
        CerrarCaja();
        GatoEnCaja();
        StartCoroutine(RevisarCaja());
    }

    IEnumerator RevisarCaja(){
        Debug.Log("Revisando caja");
        if (EstadoCaja() != 1)
        {
            yield return new WaitForSeconds(5);
            MostrarGato();
        }else
        {
            StartCoroutine(RevisarCaja());
        }
    }

    void AbrirCaja(){
        GetComponent<Animator>().SetInteger("EstadoCaja", 1);
    }

    void CerrarCaja(){
        GetComponent<Animator>().SetInteger("EstadoCaja", 0);
        GatoEnCaja();
    }

    void GatoMuerto(){
        GetComponent<Animator>().SetInteger("EstadoGato", 1);
    }

    void GatoVivo(){
        GetComponent<Animator>().SetInteger("EstadoGato", 2);
    }

    void GatoEnCaja(){
        GetComponent<Animator>().SetInteger("EstadoGato", 3);
    }

    int EstadoCaja(){
        return GetComponent<Animator>().GetInteger("EstadoCaja");
    }
}
