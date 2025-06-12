using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreController : MonoBehaviour{

    [SerializeField] TextMeshProUGUI texto_puntaje;
    private int puntaje_inicial = 0;
    private int puntaje_actual;
    [SerializeField] int puntaje_ganar;

    private void Start(){
        texto_puntaje.text = "Puntaje: " + puntaje_inicial;

    }

    private void OnEnable(){
        CanchaController.OnScore += SumarPuntaje;

    }

    private void OnDisable()
    {
        CanchaController.OnScore -= SumarPuntaje;

    }

    private void SumarPuntaje(int cantidad){
        puntaje_actual += cantidad;
        texto_puntaje.text = "Puntaje: " + puntaje_actual;

        /*if (puntaje_actual == puntaje_ganar && !ganar)
        {
            Debug.Log("Ganaste");
            ganar = true;

        */

    }

}
