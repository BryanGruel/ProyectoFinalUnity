using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnermyAvion2 : MonoBehaviour
{
    public float speed = 50;
    float timer = 0;
    public float timeBtwSpawn = 5;

    public GameObject MisilPrefab;
    public Transform firePoint;

    public static EnermyAvion2 instance;


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
        Move();
        Seguir();
      
    }

    void Move()
    {
       transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void Seguir()
    {
        timer += Time.deltaTime;
        if(timer >= timeBtwSpawn)
        {
           timer = 0;
           transform.LookAt(SpawnerEnemy.instance.ObjetivoPlayer.position);
        }
    }

    public void InstanciarMisil1()
    {
        Instantiate(MisilPrefab, firePoint.position, firePoint.rotation);

    }

}
