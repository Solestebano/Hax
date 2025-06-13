using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanchaController : MonoBehaviour{
    public static event Action OnAnotar;

    void OnTriggerEnter2D(Collider2D other){
        if (other.tag == "Bola"){
            OnAnotar?.Invoke();

        }

    }

}
