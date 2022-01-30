using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InputManagement : MonoBehaviour
{
    
[SerializeField] GameObject titleScreen;
    public void StartGame()
    {
       titleScreen.SetActive(false);
    }
}
