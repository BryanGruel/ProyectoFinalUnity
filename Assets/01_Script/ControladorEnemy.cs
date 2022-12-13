using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorEnemy : MonoBehaviour
{
    public Transform ObjetivoPlayer2;
    public static ControladorEnemy instance;

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
        
    }

    public void SeguirEnemyPlaye2()
    {
      transform.LookAt(ObjetivoPlayer2.position);
    }
}
