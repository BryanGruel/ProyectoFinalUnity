using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using Random=UnityEngine.Random;


public class ContraladorMisil : MonoBehaviour
{
    public int misil=10;
    public string Aviso = "!Emty!";
    public TMP_Text MisilTxt;
    public static ContraladorMisil instance;

    //Dispara Bala
    public GameObject MisilPrefab;
    public Transform firePoint;
    public AudioClip SoundEffect;

    //Seguir Misil Enemy
    //public Transform ObjetivoEnemy;
     //public List<Transform> items;

    
    
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
      MisilTxt.text = "Missils: " + misil.ToString();
      //BuscarEnemy();
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    
    public void Attackmisill()
    {
        if(misil !=0)
        {
             Instantiate(MisilPrefab, firePoint.position, firePoint.rotation);
             AudioManager.instance.PlaySFX(SoundEffect);
             ConteoMisil();
        }
        else if(misil == 0)
        {
            MensajeRecargarMisil();
        }
      
    }

    public void ConteoMisil()
    {
      misil--;
      MisilTxt.text = "Missils: " + misil.ToString();
    }

    public void MensajeRecargarMisil()
    {
        if(misil == 0)
        {
          MisilTxt.text = "Missils: " + Aviso.ToString();
        }
        else if(misil != 0)
        {
          MisilTxt.text = "Missils: " + misil.ToString();
        }
    }

    // public void BuscarEnemy()
    // {
    //     //Vector3 dir = ObjetivoEnemy.position - transform.position;
    //     //float angleY = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg - 0; //Para que rote al momento de buscarlo
    //     //transform.rotation = Quaternion.Euler(0, angleY , 0);

    //    // var aleatorio = (items[Random.Range(0, items.Count)]);
    //     transform.LookAt(ObjetivoEnemy.position);
        
      
    // }

}
