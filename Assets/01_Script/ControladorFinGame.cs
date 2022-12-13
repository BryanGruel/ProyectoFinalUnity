using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControladorFinGame : MonoBehaviour
{
    public void OverGame()
    {
      SceneManager.LoadScene("SampleScene");
    }
}
