using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gyroscopio : MonoBehaviour
{
      // Gyroscopio
    Gyroscope gyro;
    public Transform playerPiloto;
    public bool gyroEnabled = true;
    float sensivity = 50f;
    public float x;
    public float y;
    public float speed=20;
    Inputs inputs;
    Vector3 dir = Vector3.zero;
    public Rigidbody rb;
    public bool alive = true;


    // Start is called before the first frame update
    void Start()
    {
         // verificamos si hay gyroscopio
        if (SystemInfo.supportsGyroscope)
        {
            gyro = Input.gyro;
            gyro.enabled = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(alive)
        {
        rb.velocity = new Vector3(dir.x * speed, rb.velocity.y, dir.y * speed);
         if (gyroEnabled)
         {
             x = Input.gyro.rotationRate.x;
             y = Input.gyro.rotationRate.y;
             float xFiltered = FilerGyroValue(x);
                playerPiloto.RotateAround(transform.position,transform.right, -xFiltered * sensivity * Time.deltaTime);
             float yFiltered = FilerGyroValue(y);
                playerPiloto.RotateAround(playerPiloto.position,transform.up, -yFiltered * sensivity * Time.deltaTime);   
          }
        }
    }

     float FilerGyroValue(float axis)
    {
        if (axis < -0.1f || axis > 0.1f)
        {
            return axis;
        } 
        else
        {
             return 0;
        }    
    }
}
