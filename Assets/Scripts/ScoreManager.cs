using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour{
    #region Variables

    [SerializeField] TextMeshProUGUI texto_puntaje;
    private int puntaje_inicial = 0;
    public int puntaje_actual { get; private set; }

    #endregion

    private void Start(){
        puntaje_actual = puntaje_inicial;
        ActualizarTexto();

    }

    public void SumarPuntaje(){
        puntaje_actual++;
        ActualizarTexto();

    }

    private void ActualizarTexto(){
        texto_puntaje.text = "Puntaje: " + puntaje_actual;

    }

}
