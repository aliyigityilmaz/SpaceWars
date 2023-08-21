using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    public GameObject StopMenu;
    private bool isPaused;
    public GameObject HelpMenu;
    //public GameObject soundison;
    //public GameObject soundisoff;

    public Button muteButton;
    public AudioSource[] allAudioSources;

    private bool isMuted = false;

    // Start is called before the first frame update
    void Start()
    {
        //soundison.SetActive(true);
        //soundisoff.SetActive(false);
        isPaused = false;
        StopMenu.SetActive(false);
        HelpMenu.SetActive(false);
        Time.timeScale = 1.0f;

        muteButton.onClick.AddListener(ToggleMute);
    }

    // Update is called once per frame
    void Update()
    {

        allAudioSources = FindObjectsOfType<AudioSource>();
        if (isPaused == false)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                isPaused = true;
                PauseGame();
            }
        }
        else if (isPaused == true)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                isPaused = false;
                ResumeGame();
            }
        }
        
    }
    public void PauseGame()
    {
        Time.timeScale = 0.0f;
        isPaused = true;
        StopMenu.SetActive(true);
    }
    public void ResumeGame()
    {
        Time.timeScale = 1.0f;
        StopMenu.SetActive(false);
        HelpMenu.SetActive(false);
        isPaused= false;
    }
    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void RestartScene()
    {
        SceneManager.LoadScene(1);
    }
    public void HelpOpen()
    {
        if (HelpMenu.activeSelf)
        {
            HelpMenu.SetActive(false);
        }
        if (!HelpMenu.activeSelf)
        {
            HelpMenu.SetActive(true);
        }
    }
    public void CloseSound()
    {
        //soundisoff.SetActive(true);
        //soundison.SetActive(false);
    }
    public void OpenSound()
    {
        //soundisoff.SetActive(false);
        //soundison.SetActive(true);
    }
    private void ToggleMute()
    {
        isMuted = !isMuted;

        foreach (var audioSource in allAudioSources)
        {
            audioSource.mute = isMuted;
        }
    }
}
