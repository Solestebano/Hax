using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour{
    private void Awake(){
        Application.targetFrameRate = 60;

    }

    private void OnEnable(){
        

    }

    private void OnDisable(){
        

    }

    public void ReiniciarEscena(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

}
