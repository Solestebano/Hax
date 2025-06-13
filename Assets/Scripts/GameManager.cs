using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class GameManager : MonoBehaviour{
    #region Variables

    [SerializeField] GameObject jugador;
    [SerializeField] GameObject bola;
    [SerializeField] TextMeshProUGUI texto_ganador;
    [SerializeField] TimerManager timer;
    [SerializeField] ScoreManager score;
    Rigidbody2D rb_jugador;
    Rigidbody2D rb_bola;

    [SerializeField] int puntaje_ganar;
    [SerializeField] float desaceleracion = 5f;
    private float drag_original;
    private Vector3 posicion_original;
    private bool ganar = false;

    #endregion

    private void Awake(){
        Application.targetFrameRate = 60;

        rb_bola = bola.GetComponent<Rigidbody2D>();
        rb_jugador = jugador.GetComponent<Rigidbody2D>();

        drag_original = rb_bola.drag;
        posicion_original = jugador.transform.position;
    }

    private void OnEnable()
    {
        CanchaController.OnAnotar += Anotar;

    }

    private void OnDisable()
    {
        CanchaController.OnAnotar -= Anotar;

    }

    private void Update(){
        if (timer.duracion_actual == 0 && !ganar) {
            ganar = true;
            StartCoroutine(GanarCorutina());

        }

    }

    private void Anotar(){
        StartCoroutine(AnotarCorutina());   
    
    }

    private void ReiniciarAtributos(){
        bola.transform.position = Vector3.zero;
        rb_bola.drag = drag_original;
        rb_bola.velocity = Vector2.zero;

        jugador.transform.position = posicion_original;
        rb_jugador.velocity = Vector2.zero;

    }

    public void ReiniciarEscena(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
    IEnumerator AnotarCorutina(){
        yield return null;
        //Al anotar
        timer.PararContador(true);
        rb_bola.drag = desaceleracion; //Desacelerar la bola

        //Si se gana
        if (score.puntaje_actual == puntaje_ganar){
            ganar = true;
            StartCoroutine(GanarCorutina());
            yield break;

        }

        yield return new WaitForSeconds(2f);

        //Despues de anotar
        timer.PararContador(false);
        ReiniciarAtributos();

    }

    IEnumerator GanarCorutina(){
        texto_ganador.DOFade(1f, 1f);
        yield return new WaitForSeconds(2f);
        ReiniciarEscena();

    }

}