using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MisilPlayer : MonoBehaviour
{
    public float speed = 50;
    public Rigidbody rb;
    public Vector3 direction = new Vector3(0, 0, 1); // Se va a mover hacia arriba
    public AudioClip destroySoundEffect;
    public GameObject destroyedEffect;

    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
      transform.LookAt(ContraladorMisil.instance.ObjetivoEnemy.position);
      transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }


    void OnCollisionEnter(Collision collision)
    {
      if(collision.gameObject.CompareTag("Enemy"))
      {
         AudioManager.instance.PlaySFX(destroySoundEffect);
         Instantiate(destroyedEffect, transform.position, destroyedEffect.transform.rotation);
         Destroy(gameObject);
         Destroy(collision.gameObject);    
      }
      else if(collision.gameObject.CompareTag("BarcoEnemy"))
      {
         BarcoEnemy barcoEnemy = collision.gameObject.GetComponent<BarcoEnemy>();
         barcoEnemy.TakeDamageMisil();
         AudioManager.instance.PlaySFX(destroySoundEffect);
         Instantiate(destroyedEffect, transform.position, destroyedEffect.transform.rotation);
         Destroy(gameObject);
      }
      else if(collision.gameObject.CompareTag("BarcoPlayer"))
      {
         Destroy(gameObject);
      }

    }
}
