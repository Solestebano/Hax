using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class CanchaController : MonoBehaviour{
    [SerializeField] GameObject jugador;
    [SerializeField] GameObject bola;
    [SerializeField] GameManager game_manager;
    [SerializeField] TextMeshProUGUI texto_ganador;

    Rigidbody2D rb_jugador;
    Rigidbody2D rb_bola;

    private float drag_original;
    private Vector3 posicion_original;
    private bool ya_gano = false;

    public static event Action<int> OnScore;

    private void Start(){
        rb_bola = bola.GetComponent <Rigidbody2D>();
        rb_jugador = jugador.GetComponent<Rigidbody2D>();

        drag_original = rb_bola.drag;
        posicion_original = jugador.transform.position;


    }

    private void Update()
    {
        if (game_manager.ganar && !ya_gano)
        {
            ya_gano = true;
            StartCoroutine(Ganar());
        }
    }

    void OnTriggerEnter2D(Collider2D other){
        if (other.tag == "Bola"){
            OnScore?.Invoke(1);

            //StartCoroutine(Anotar());

        }

    }
    
    IEnumerator Anotar(){
        game_manager.PararContador(true);

        rb_bola.drag = 5f;

        if (game_manager.ganar == true){
            StartCoroutine(Ganar());

            yield break;
        
        }

        yield return new WaitForSeconds(2f);

        game_manager.PararContador(false);

        bola.transform.position = Vector3.zero;
        rb_bola.drag = drag_original;
        rb_bola.velocity = Vector2.zero;

        jugador.transform.position = posicion_original;
        rb_jugador.velocity = Vector2.zero;

    }

    IEnumerator Ganar(){
        texto_ganador.DOFade(1f, 1f);
        yield return new WaitForSeconds(2f);

        game_manager.ReiniciarEscena();

    }

}
