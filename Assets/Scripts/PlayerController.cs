using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour{

    [SerializeField] Rigidbody2D rb;
    [SerializeField] SpriteRenderer sr;
    [SerializeField] GameObject patada;

    [SerializeField] float velocidad; 
    [SerializeField] float salto;

    private Vector2 direccion_movimiento;
    private bool accion;
    private float velocidad_inicial;

    private void Awake()
    {
        velocidad_inicial = velocidad;
    }

    private void FixedUpdate(){
        rb.AddForce(direccion_movimiento * velocidad, ForceMode2D.Force);
        //rb.velocity = direccion_movimiento.normalized * velocidad;

        if (accion){
            velocidad = velocidad_inicial * 0.5f;
            sr.color = Color.red;
            patada.SetActive(true);
        
        }else{
            velocidad = velocidad_inicial;
            sr.color = Color.white;
            patada.SetActive(false);

        }

    }

    public void Movimiento(InputAction.CallbackContext context){
        direccion_movimiento = context.ReadValue<Vector2>();

    }

    public void Acciones(InputAction.CallbackContext context){
        if (context.started){
            accion = true;

        }
        else if (context.canceled){
            accion = false;

        }

    }

}
