using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class Player : MonoBehaviour
{
    Inputs inputs;
    Vector3 dir = Vector3.zero;
    public Rigidbody rb;
    public float speed=20;
    public float rotationSpeed= 30;

    //Rotacion elise
    private float velocidadActual;
    [Range(10f, 10000f)]
    private float propelSpeedMultiplier = 100f;
    public GameObject[] Elise;
    [Header("Moving speed elise")]
    [Range(5f, 100f)]
    private float velocidadPredeterminada = 10f;


    //Barra de vida
    public Image lifeBar;
    float maxLife = 15;
    float life = 14;
    public bool alive = true;

    //Panel GameOver
    public GameObject gameOverPanel;

    // Gyroscopio
    Gyroscope gyro;
    public Transform playerPiloto;
    public bool gyroEnabled = true;
    float sensivity = 50f;
    public float x;
    public float y;

    void Awake()
    {
        inputs = new Inputs();
        inputs.Player.Movement.performed += ctx => dir = ctx.ReadValue<Vector2>(); //si presiono algo
        inputs.Player.Movement.canceled += ctx => dir = Vector2.zero; // si no estoy presionando nada
        inputs.Player.Attack.performed += ctx => Attack();
        inputs.Player.AttackMisil.performed += ctx => AttackMisil();
        inputs.Player.ReloadBulls.performed += ctx => ReloadBull();
        inputs.Player.GameOver.performed += ctx => OverGame();
    }
    void OnEnable()
    {
        inputs.Enable();
    } 

    void OnDisable()
    {
        inputs.Disable();
    }
     
    // Start is called before the first frame update
    void Start()
    {
        //Elise
        velocidadActual = velocidadPredeterminada;
        //Panel danio y vida
        gameOverPanel.SetActive(false);
        lifeBar.fillAmount = life / maxLife; 
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
   
         Move(); 
         //Giroscopio();
         ValidarBalas();
         ValidarMisil();
         RotacionElise(Elise);
       
    }
    void Giroscopio()
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


    void Move()
    {
        //VELOCIDAD RECTO MOVIMIENTO
        //transform.Translate(Vector3.forward * speed * Time.deltaTime);

        // INCLINACIÓN: Left - Right
        transform.Rotate(Vector3.forward * rotationSpeed * dir.x * -1 * Time.deltaTime);
        //transform.Rotate(0, 0, 1);

        // INCLINACIÓN: Arriba - abajo
        transform.Rotate(Vector3.right * rotationSpeed * dir.y * Time.deltaTime);

        // DESPLAZAMIENTO MEDIO INCLINADO: Left - Right
         //transform.Rotate(Vector3.up * rotationSpeed * dir.x * Time.deltaTime);
    }

    void RotacionElise(GameObject[] RotarElise)
    {
        float _propelSpeed = velocidadActual * propelSpeedMultiplier;

        for (int i = 0; i < RotarElise.Length; i++)
        {
            RotarElise[i].transform.Rotate(Vector3.forward * -_propelSpeed * Time.deltaTime);
        }
    }

    // BALAS
    public void Attack()
    {
       ControladorBulls.instance.AttackBull();
    }

    public void ReloadBull()
    {
      ControladorBulls.instance.RecargarBalas();
    }
    
    public void ValidarBalas()
    {
      ControladorBulls.instance.MensajeRecargarBalas();
    }

    public void TakeDamage()
    {
        Debug.Log("damage");
        life--;
        lifeBar.fillAmount = life / maxLife; 
        if(life <=1)
        {
            Debug.Log("gameover");
            StartCoroutine(ShowGameOver());
        }
    }

    // MISIL
    public void AttackMisil()
    {
       ContraladorMisil.instance.Attackmisill();
    }
    public void ValidarMisil()
    {
      ContraladorMisil.instance.MensajeRecargarMisil();
    }

    public void OverGame()
    {
      SceneManager.LoadScene("SampleScene");
    }

    IEnumerator ShowGameOver()
    {
        alive = false;
        yield return new WaitForSeconds(1f);
        gameOverPanel.SetActive(true);
    }



}


