using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour{
    [SerializeField] TimerManager timer;
    private Rigidbody2D rb;

    [SerializeField] float fuerza;
    private Vector2 direccion;
    private const string TAG_PATADA = "Patada";
    private const string TAG_JUGADOR = "Player";

    private void Awake(){
        rb = GetComponent<Rigidbody2D>();

    }

    private void OnCollisionEnter2D(Collision2D collision){
        if (collision.collider.CompareTag(TAG_PATADA)){
            ComprobarPrimerMovimiento();

            direccion = (rb.position - (Vector2)collision.transform.position).normalized;
            rb.AddForce(direccion * fuerza, ForceMode2D.Impulse);


        }
     
        if (collision.collider.CompareTag(TAG_JUGADOR)){
            ComprobarPrimerMovimiento();

        }

    }
    private void ComprobarPrimerMovimiento(){
        if (timer.primer_movimiento == false && timer.esta_pausado == false){
            timer.EmpezarContador();

        }

    }

}
