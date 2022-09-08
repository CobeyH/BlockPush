using UnityEngine;
using System;
using System.IO;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    bool isGameOver = false;
    public GameObject gameLostMenu;
    public GameObject gameWonMenu;
    public GameObject pauseMenu;
    public GameObject dofVolume;
    AudioManager audioManager;

    void Start()
    {
        Time.timeScale = 1f;
        dofVolume.SetActive(false);
        audioManager = FindObjectOfType<AudioManager>();
        audioManager.Play("Music");
    }
    void Update()
    {
        HandlePauseMenu();
    }

    void HandlePauseMenu()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            MenuController menuController = pauseMenu.GetComponent<MenuController>();
            bool isGamePaused = menuController.MenuUI.activeSelf;
            if (isGamePaused)
            {
                menuController.HideMenu();
                DisableDOF();
            }
            else
            {
                menuController.ShowMenu();
                EnableDOF();
            }
        }
    }
    void HandleGameOver(GameObject menuObject)
    {
        if (!isGameOver && menuObject != null)
        {
            isGameOver = true;
            SaveData();
            audioManager.Stop("Music");
            StartCoroutine(EndGameSlow(menuObject));
        }
    }

    IEnumerator EndGameSlow(GameObject menuObject)
    {
        for (float speed = 1; speed > 0; speed -= 0.1f)
        {
            Time.timeScale = speed;
            yield return new WaitForSecondsRealtime(0.1f);
        }

        EnableDOF();
        menuObject.GetComponent<MenuController>().ShowMenu();
    }

    public void LoseGame()
    {
        HandleGameOver(gameLostMenu);
    }

    public void WinGame()
    {
        HandleGameOver(gameWonMenu);
        audioManager.Play("Victory");
        int furthestLevel = PlayerPrefs.GetInt("progress");
        if (ApplicationData.currentLevel == furthestLevel)
        {
            PlayerPrefs.SetInt("progress", furthestLevel + 1);
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

    public void EnableDOF()
    {
        dofVolume.SetActive(true);
    }
    public void DisableDOF()
    {
        dofVolume.SetActive(false);
    }

    public void RestartLevel()
    {
        isGameOver = false;
        int levelIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(levelIndex);
    }

    public void LoadNextLevel()
    {
        int levelCount = GetComponent<ChunkSpawner>().GetLevelCount();
        if (ApplicationData.currentLevel >= levelCount - 1)
        {
            LoadMenu();
        }
        else
        {
            ApplicationData.currentLevel++;
            RestartLevel();
        }
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene("LevelSelection");
    }

    private class JSONData
    {
        public int timePlayed = 0;
        public int timeJsonMade = 0;
        public string gameName = "blocky-pushy";
        public int score = 0;
    }
}

