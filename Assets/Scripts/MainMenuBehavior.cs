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
        _tutorialToggle = false;
        _mainMenu.SetActive(true);
        _tutorialMenu.SetActive(false);
    }

    private void Update()
    {
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

    public void TutorialToggle() 
    {
        _tutorialToggle = !_tutorialToggle;
    }

    public void QuitGame() 
    {
        Application.Quit();
    }

    public void PlayGame() 
    {
        Application.LoadLevel("play_scene");
    }
}
