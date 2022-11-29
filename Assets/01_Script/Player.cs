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
    Vector2 dir = Vector2.zero;
    public Rigidbody rb;
    public float speed=5;
    public float rotationSpeed=10;

    //Rotacion elise
    private float velocidadActual;
    [Range(10f, 10000f)]
    private float propelSpeedMultiplier = 100f;
    public GameObject[] Elise;
    [Header("Moving speed elise")]
    [Range(5f, 100f)]
    private float velocidadPredeterminada = 10f;


    //Dispara Bala
    public GameObject bulletPrefab;
    public Transform firePoint;
    public Transform firePoint2;

    void Awake()
    {
        inputs = new Inputs();
        inputs.Player.Movement.performed += ctx => dir = ctx.ReadValue<Vector2>(); //si presiono algo
        inputs.Player.Movement.canceled += ctx => dir = Vector2.zero; // si no estoy presionando nada
        inputs.Player.Attack.performed += ctx => Attack();
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
    }

    // Update is called once per frame
    void Update()
    {
        RotacionElise(Elise);
        //rb.velocity = new Vector3(dir.x * speed, rb.velocity.y, dir.y * speed);
        //transform.Translate(Vector3.forward * velocidadActual * Time.deltaTime);

        //Inclinacion Left - Right
        transform.Rotate(Vector3.up * rotationSpeed * dir.x * Time.deltaTime);
        
    }

    void RotacionElise(GameObject[] RotarElise)
    {
        float _propelSpeed = velocidadActual * propelSpeedMultiplier;

        for (int i = 0; i < RotarElise.Length; i++)
        {
            RotarElise[i].transform.Rotate(Vector3.forward * -_propelSpeed * Time.deltaTime);
        }
    }

    void Attack()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Instantiate(bulletPrefab, firePoint2.position, firePoint2.rotation);
    }

}


