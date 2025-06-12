using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreController : MonoBehaviour{

    [SerializeField] TextMeshProUGUI texto_puntaje;
    private int puntaje = 0;
    private int puntaje_actual;
    [SerializeField] public int puntaje_ganar;

    private void Start(){
        texto_puntaje.text = "Puntaje: " + puntaje;

    }

    public void SumarPuntaje(int cantidad){
        puntaje_actual += cantidad;
        texto_puntaje.text = "Puntaje: " + puntaje;

        /*if (puntaje_actual == puntaje_ganar && !ganar)
        {
            Debug.Log("Ganaste");
            ganar = true;

        */

        }

    }


}
