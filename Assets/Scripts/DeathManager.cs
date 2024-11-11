using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DeathManager : MonoBehaviour
{
    public GameObject message;
    public GameObject button;

    public void BackToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void ShowDeathOverlay()
    {
        message.SetActive(true);
        button.SetActive(true);
        Time.timeScale = 0f;
    }
}