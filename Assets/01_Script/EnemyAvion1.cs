using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAvion1 : MonoBehaviour
{
    public float speed = 50;
    float timer = 0;
    public float timeBtwSpawn = 5;

    public GameObject MisilPrefab2;
    public Transform firePoint2;

    public static EnemyAvion1 instance;
    public AudioClip SoundEffectAtack;

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
           transform.LookAt(ControladorEnemy.instance.ObjetivoPlayer2.position);
        }
    }

    public void InstanciarMisil2()
    {
        Instantiate(MisilPrefab2, firePoint2.position, firePoint2.rotation);
        AudioManager.instance.PlaySFX(SoundEffectAtack);

    }

}
