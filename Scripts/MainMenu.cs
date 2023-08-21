using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject CreditsMenu;
    public AudioSource bgMusic;
    public GameObject difficulty;
    public GameObject development;

    // Start is called before the first frame update
    void Start()
    {
        mainMenu.SetActive(true); CreditsMenu.SetActive(false);
        difficulty.SetActive(false);
        Time.timeScale = 1.0f;
        development.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void Play()
    {
        difficulty.SetActive(true);
        mainMenu.SetActive(false);
        
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void Credits()
    {
        CreditsMenu.SetActive(true);
        mainMenu.SetActive(false);

    }
    public void BackCredits()
    {
        development.SetActive(false);
        CreditsMenu.SetActive(false);
        difficulty.SetActive(false);
        mainMenu.SetActive(true);
    }
    public void PauseGame()
    {
        Time.timeScale = 0.0f;
    }

    public void EasyMode()
    {
        SceneManager.LoadScene(1);
    }
    public void NormalMode()
    {
        SceneManager.LoadScene(2);
    }
    public void HardMode()
    {
        SceneManager.LoadScene(3);
    }
    public void CoopButton()
    {
        mainMenu.SetActive(false);
        development.SetActive(true);
    }

}
