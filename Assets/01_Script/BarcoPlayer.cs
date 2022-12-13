using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;


public class BarcoPlayer : MonoBehaviour
{
    //Barra de vida
    public Image lifeBar;
    float maxLife = 15;
    float life = 14;
    public bool alive = true;

    public GameObject GameOverPanel;

    //Animacion Danio Barco
    public GameObject DanioEffect;
    public Transform firePoint;


    // Start is called before the first frame update
    void Start()
    {
        GameOverPanel.SetActive(false);
        lifeBar.fillAmount = life / maxLife; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   
    public void TakeDamageMisil()
    {
        life--;
        lifeBar.fillAmount = life / maxLife; 
        if(life <=5)
        {
           //Animacion
           Instantiate(DanioEffect, firePoint.position, firePoint.rotation);

        }
        if(life <=1)
        {
            StartCoroutine(ShowWinGame());
        }
    }

    public void WinGame()
    {
      SceneManager.LoadScene("SampleScene");
    }

    IEnumerator ShowWinGame()
    {
        alive = false;
        yield return new WaitForSeconds(1f);
        GameOverPanel.SetActive(true);
    }
}
