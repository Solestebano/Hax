using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class GameManager : MonoBehaviour{
    #region Variables

    [SerializeField] GameObject jugador1;
    [SerializeField] GameObject jugador2;
    [SerializeField] GameObject bola;
    [SerializeField] TextMeshProUGUI texto_ganador;
    [SerializeField] TimerManager timer;
    [SerializeField] ScoreManager score;
    Rigidbody2D rb_jugador1;
    Rigidbody2D rb_jugador2;
    Rigidbody2D rb_bola;

    [SerializeField] int puntaje_ganar;
    [SerializeField] float desaceleracion = 5f;
    private float drag_original;
    private Vector3 j1_posicion_original;
    private Vector3 j2_posicion_original;
    private bool ganar = false;
    private bool ya_anoto = false;

    #endregion

    private void Awake(){
        Application.targetFrameRate = 60;

        rb_bola = bola.GetComponent<Rigidbody2D>();
        rb_jugador1 = jugador1.GetComponent<Rigidbody2D>();
        rb_jugador2 = jugador2.GetComponent<Rigidbody2D>();

        drag_original = rb_bola.drag;
        j1_posicion_original = jugador1.transform.position;
        j2_posicion_original = jugador2.transform.position;

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
        //A�adir empate
        if (timer.duracion_actual == 0 && !ganar) {
            ganar = true;
            StartCoroutine(GanarCorutina());

        }

    }

    private void Anotar(){
        if (ya_anoto == false){ 
            StartCoroutine(AnotarCorutina());

        }

    }

    private void ReiniciarAtributos(){
        bola.transform.position = Vector3.zero;
        rb_bola.drag = drag_original;
        rb_bola.velocity = Vector2.zero;

        jugador1.transform.position = j1_posicion_original;
        rb_jugador1.velocity = Vector2.zero;
        jugador2.transform.position = j2_posicion_original;
        rb_jugador2.velocity = Vector2.zero;

        ya_anoto = false;

    }

    public void ReiniciarEscena(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
    IEnumerator AnotarCorutina(){
        yield return null;
        //Al anotar
        score.SumarPuntaje();
        timer.PararContador(true);
        ya_anoto = true;
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