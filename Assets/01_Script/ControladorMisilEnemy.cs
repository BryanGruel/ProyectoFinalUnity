using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using Random=UnityEngine.Random;

public class ControladorMisilEnemy : MonoBehaviour
{
 
    public static ControladorMisilEnemy instance;

    //Dispara Bala
    //public AudioClip SoundEffect;

    //Seguir Misil Enemy
    public Transform ObjetivoEnemyPlayer;


    float timer = 0;
    public float timeBtwSpawn = 25;

    
    void Awake()
    {
        if(instance ==null)
        {
            instance = this;
        }
    }


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
     
       AvisioAtackMisil();
    }
    
    public void AvisioAtackMisil()
    {
        timer += Time.deltaTime;
        if(timer >= timeBtwSpawn)
        {
            timer = 0;
            EnermyAvion2.instance.InstanciarMisil1();
            //AudioManager.instance.PlaySFX(SoundEffect);
        }
    }

    public void BuscarEnemyPlayer()
    {
        transform.LookAt(ObjetivoEnemyPlayer.position);
    }
}
