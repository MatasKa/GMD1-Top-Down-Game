using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public PlayerInput input;

    private void Awake()
    {
        input = new PlayerInput();
        input.Enable();
    }

    public void OnA()
    {
        Debug.Log("Jump (A) was pressed!");
        SceneManager.LoadScene("Arena");
    }
    public void OnB()
    {
        Debug.Log("B was pressed!");
        Application.Quit();
    }
}
