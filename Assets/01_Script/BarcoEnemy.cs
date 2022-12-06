using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class BarcoEnemy : MonoBehaviour
{
    //Barra de vida
    public Image lifeBar;
    float maxLife = 15;
    float life = 14;
    public bool alive = true;

    public GameObject WinGamePanel;


    // Start is called before the first frame update
    void Start()
    {
        WinGamePanel.SetActive(false);
        lifeBar.fillAmount = life / maxLife; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamageMisil()
    {
        life = life - 2;
        lifeBar.fillAmount = life / maxLife; 
        if(life <=1)
        {
            StartCoroutine(ShowWinGame());
        }
    }

    public void TakeDamageBala()
    {
        life--;
        lifeBar.fillAmount = life / maxLife; 
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
        WinGamePanel.SetActive(true);
    }
}
