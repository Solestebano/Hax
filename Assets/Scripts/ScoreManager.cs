using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour{
    [SerializeField] TextMeshProUGUI texto_puntaje;
    private int puntaje_inicial = 0;
    private int puntaje_actual;
    [SerializeField] int puntaje_ganar;

    public static event Action OnGanar;

    private void Start(){
        texto_puntaje.text = "Puntaje: " + puntaje_inicial;

    }

    private void Update(){
        if (puntaje_actual == puntaje_ganar){
            OnGanar?.Invoke();
        
        }
    
    }

    private void OnEnable(){
        CanchaController.OnAnotar += SumarPuntaje;

    }

    private void OnDisable()
    {
        CanchaController.OnAnotar -= SumarPuntaje;

    }

    private void SumarPuntaje(){
        puntaje_actual++;
        texto_puntaje.text = "Puntaje: " + puntaje_actual;

        /*if (puntaje_actual == puntaje_ganar && !ganar)
        {
            Debug.Log("Ganaste");
            ganar = true;

        */

    }

}
