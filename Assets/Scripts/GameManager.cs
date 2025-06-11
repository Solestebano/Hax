using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour{

    [SerializeField] public int puntaje_ganar;
    private int puntaje_actual;
    public bool ganar = false;

    [SerializeField] TMP_Text texto_contador;
    [SerializeField] float duracion;
    [SerializeField] float duracion_interpolacion;
    private float duracion_actual;
    private bool empezo_animacion = false;
    private bool primer_movimiento = false;
    private bool esta_pausado = false;


    private void Awake(){
        Application.targetFrameRate = 60;
        duracion_actual = duracion;

    }

    private void Update(){
        //Condicion para ganar

        if (duracion_actual == 0 && !ganar){
            ganar = true;

        }

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
    public void SumarPuntaje(int cantidad)
    {
        puntaje_actual += cantidad;

        if (puntaje_actual == puntaje_ganar && !ganar)
        {
            Debug.Log("Ganaste");
            ganar = true;

        }

    }

    public void ReiniciarEscena(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

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
