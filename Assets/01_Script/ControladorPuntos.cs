using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using UnityEngine.UI;

public class ControladorPuntos : MonoBehaviour
{
    public int points=0;
    public TMP_Text pointsTxt;
    public static ControladorPuntos instance;

    void Awake()
    {
        if(instance ==null)
        {
            instance = this;
        }
    }

    public void AddPoints()
    {
      points++;
      pointsTxt.text = "D.E:" + points.ToString();
    }
    // Start is called before the first frame update
    void Start()
    {
        pointsTxt.text = "D.E: " + points.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
