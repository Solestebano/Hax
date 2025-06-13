using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanchaController : MonoBehaviour{
    private const string TAG_BOLA = "Bola";

    public static event Action OnAnotar;

    void OnTriggerEnter2D(Collider2D other){
        if (other.tag == TAG_BOLA){
            OnAnotar?.Invoke();

        }

    }

}
