using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreController : MonoBehaviour{

    [SerializeField] TextMeshProUGUI texto_puntaje;
    private int puntaje = 0;

    private void Start(){
        texto_puntaje.text = "Puntaje: " + puntaje;

    }


}
