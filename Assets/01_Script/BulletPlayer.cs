using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPlayer : MonoBehaviour
{
    public float speed = 50;
    public Rigidbody rb;
    public Vector3 direction = new Vector3(0, 0, 1); // Se va a mover hacia arriba
    public AudioClip destroySoundEffect;
    public GameObject destroyedEffect;

    // Ganaste ganaste;
    // Player player;
    // SpawnerMeteoro spawnerMeteoro;

    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
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

    }

}
