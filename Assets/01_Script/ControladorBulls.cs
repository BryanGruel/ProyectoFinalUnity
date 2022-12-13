using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;


public class ControladorBulls : MonoBehaviour
{
    public int bulls=40;
    public string RecarhaAhora = "!Reload!";
    public TMP_Text BullsTxt;
    public static ControladorBulls instance;

    //Dispara Bala
    public GameObject bulletPrefab;
    public Transform firePoint;
    public Transform firePoint2;
    public AudioClip SoundEffect;
    public AudioClip SoundEffectReloadBull;

    public GameObject DisparoEffect;


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
      BullsTxt.text = "Bulls: " + bulls.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AttackBull()
    {
        if(bulls !=0)
        {
             Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
             Instantiate(bulletPrefab, firePoint2.position, firePoint2.rotation);

             Instantiate(DisparoEffect, firePoint.position, firePoint.transform.rotation);
             Instantiate(DisparoEffect, firePoint2.position, firePoint2.transform.rotation);
             AudioManager.instance.PlaySFX(SoundEffect);
             ConteoBalas();
        }
        else if(bulls == 0)
        {
            MensajeRecargarBalas();
        }
      
    }

    public void ConteoBalas()
    {
      bulls = bulls -2;
      BullsTxt.text = "Bulls: " + bulls.ToString();
    }

    public void MensajeRecargarBalas()
    {
        if(bulls == 0)
        {
          BullsTxt.text = "Bulls: " + RecarhaAhora.ToString();
        }
        else if(bulls != 0)
        {
          BullsTxt.text = "Bulls: " + bulls.ToString();
        }
    }

    public void RecargarBalas()
    {
      AudioManager.instance.PlaySFX(SoundEffectReloadBull);
      bulls = 40;
      BullsTxt.text = "Bulls: " + bulls.ToString();
    }
}
