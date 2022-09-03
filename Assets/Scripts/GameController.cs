using UnityEngine;
using System;
using System.IO;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    bool isGameOver = false;
    public GameObject gameOverMenu;
    public GameObject pauseMenu;

    void Start()
    {
        Time.timeScale = 1f;
    }
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
            SaveData();
        }
    }


    // Export data to JSON format.
    void SaveData()
    {
        JSONData data = new JSONData
        {
            timePlayed = (int)Mathf.Floor(Time.time),
            timeJsonMade = (int)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds,
            score = ScoreManager.score,
        };
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.dataPath + "/pushyBlock-Data.json", json);

    }

    public void RestartLevel()
    {
        isGameOver = false;
        int levelIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(levelIndex);
    }

    private class JSONData
    {
        public int timePlayed = 0;
        public int timeJsonMade = 0;
        public string gameName = "blocky-pushy";
        public int score = 0;
    }
}

