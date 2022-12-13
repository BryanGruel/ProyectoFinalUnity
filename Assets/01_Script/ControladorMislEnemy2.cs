using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorMislEnemy2 : MonoBehaviour
{
    public static ControladorMislEnemy2 instance;

    //Seguir Misil Enemy
    public Transform ObjetivoEnemyPlayer2;


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
     
       AvisioAtackMisil2();
    }
    
    public void AvisioAtackMisil2()
    {
        timer += Time.deltaTime;
        if(timer >= timeBtwSpawn)
        {
            timer = 0;
            EnemyAvion1.instance.InstanciarMisil2();
        }
    }

    public void BuscarEnemyPlayer2()
    {
        transform.LookAt(ObjetivoEnemyPlayer2.position);
    }
}
