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
    public PlayerInput input;
    public CharacterChoice charChoice;
    public GameObject CharSelectScreen;
    private bool onCharSelect = false;

    private void Awake()
    {
        input = new PlayerInput();
        input.Enable();
    }
    public void OnA() // Warden
    {
        if (onCharSelect)
        {
            charChoice.character = 0;
            SceneManager.LoadScene("Arena");
        }
        else
        {
            CharSelectScreen.SetActive(true);
            onCharSelect = true;
        }
    }
    public void OnX() // Wolf
    {
        if (onCharSelect)
        {
            charChoice.character = 1;
            SceneManager.LoadScene("Arena");
        }
    }
    public void OnY() // Duelist
    {
        if (onCharSelect)
        {
            charChoice.character = 2;
            SceneManager.LoadScene("Arena");
        }
    }

    public void OnB()
    {
        if (onCharSelect)
        {

            CharSelectScreen.SetActive(false);
            onCharSelect = false;

        }
        else
        {
            Application.Quit();
        }
    }
}
