using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuBehavior : MonoBehaviour
{
    [SerializeField] private GameObject _mainMenu;
    [SerializeField] private GameObject _tutorialMenu;

    private bool _tutorialToggle;

    private void Start()
    {
        //Default variables
        _tutorialToggle = false;
        _mainMenu.SetActive(true);
        _tutorialMenu.SetActive(false);
    }

    private void Update()
    {
        //Display the tutorial
        if (_tutorialToggle) 
        {
            _mainMenu.SetActive(false);
            _tutorialMenu.SetActive(true);
        }
        if (!_tutorialToggle)
        {
            _mainMenu.SetActive(true);
            _tutorialMenu.SetActive(false);
        }
    }

    /// <summary>
    /// Toggle the tutorial boolean
    /// </summary>
    public void TutorialToggle() 
    {
        _tutorialToggle = !_tutorialToggle;
    }

    /// <summary>
    /// Quit the application
    /// </summary>
    public void QuitGame() 
    {
        Application.Quit();
    }

    /// <summary>
    /// Load the play scene
    /// </summary>
    public void PlayGame() 
    {
        Application.LoadLevel("play_scene");
    }
}
