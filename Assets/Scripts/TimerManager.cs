using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using DG.Tweening;

public class TimerManager : MonoBehaviour{
    #region Variables

    [SerializeField] TMP_Text texto_contador;
    [SerializeField] float duracion_contador;
    [SerializeField] float duracion_interpolacion;
    public float duracion_actual { get; set; }
    private bool empezo_animacion = false;
    private bool esta_pausado = false;
    private bool primer_movimiento = false;

    #endregion

    private void Awake(){
        duracion_actual = duracion_contador;

    }

    private void Update(){
        //Contador
        if(duracion_actual < 0) {
            duracion_actual = 0;
        
        }else if (duracion_actual != 0 && primer_movimiento){
            duracion_actual -= Time.deltaTime;
        
        }

        //Cambio de color del texto cuando queda poco tiempo
        if(duracion_actual < 30 && !empezo_animacion){
            texto_contador.DOColor(Color.red, duracion_interpolacion)
            .SetLoops(-1, LoopType.Yoyo)
            .SetEase(Ease.Linear);

            empezo_animacion = true;
        
        }

        //Actualizacion del contador
        TimeSpan tiempo = TimeSpan.FromSeconds(duracion_actual);
        texto_contador.text = tiempo.ToString(@"mm\:ss");

    }

    public void EmpezarContador(){
        primer_movimiento = true;
    
    }

    public void PararContador(bool pausa){
        primer_movimiento = false;
        esta_pausado = pausa;

    }

    public bool GetPrimerMovimiento(){
        return primer_movimiento;
    
    }

    public bool GetPausa(){
        return esta_pausado;

    }

}
