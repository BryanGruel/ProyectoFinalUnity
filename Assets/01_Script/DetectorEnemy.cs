using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectorEnemy : MonoBehaviour
{
    public Transform ObjetivoEnemy;
    public AudioClip SoundEffectDetector;

    public static DetectorEnemy instance;

    void Awake()
    {
        if(instance ==null)
        {
            instance = this;
        }
    }

    void OnTriggerEnter(Collider other)
    {
      if(other.gameObject.CompareTag("Enemy"))
      {
        AudioManager.instance.PlaySFX(SoundEffectDetector);
        ObjetivoEnemy = other.transform;
        Debug.Log("Enemy detectado");
      }
    }
}
