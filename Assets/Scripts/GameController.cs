using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    bool isGameOver = false;
    public GameObject gameOverMenu;
    public GameObject pauseMenu;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            MenuController menuController = pauseMenu.GetComponent<MenuController>();
            bool isGamePaused = menuController.MenuUI.activeSelf;
            if (isGamePaused)
            {
                menuController.HideMenu();
            }
            else
            {
                menuController.ShowMenu();
            }
        }
    }
    public void GameOver()
    {
        if (!isGameOver)
        {
            isGameOver = true;
            gameOverMenu.GetComponent<MenuController>().ShowMenu();
        }
    }

    public void RestartLevel()
    {
        int levelIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(levelIndex);
    }
}
