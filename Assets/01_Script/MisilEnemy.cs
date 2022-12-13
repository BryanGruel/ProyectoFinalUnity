using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MisilEnemy : MonoBehaviour
{
    public float speed = 130;
    public Rigidbody rb;
    public Vector3 direction = new Vector3(0, 0, 1); // Se va a mover hacia arriba
    public AudioClip destroySoundEffect;
    public GameObject destroyedEffect;

    public static MisilEnemy instance;

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
      transform.LookAt(ControladorMisilEnemy.instance.ObjetivoEnemyPlayer.position);
      transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }


    void OnTriggerEnter(Collider other)
    {
      if(other.gameObject.CompareTag("BarcoPlayer"))
      {
         BarcoPlayer barcoPlayer = other.gameObject.GetComponent<BarcoPlayer>();
         barcoPlayer.TakeDamageMisil();
         AudioManager.instance.PlaySFX(destroySoundEffect);
         Instantiate(destroyedEffect, transform.position, destroyedEffect.transform.rotation);
         Destroy(gameObject); 
      }
    }
     
}
