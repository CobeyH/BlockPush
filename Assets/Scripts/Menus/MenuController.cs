using UnityEngine;

public class MenuController : MonoBehaviour
{
    public GameObject MenuUI;
    GameController gameController;

    void Start()
    {
        gameController = FindObjectOfType<GameController>();
    }

    public void ShowMenu()
    {
        MenuUI.SetActive(true);
        Time.timeScale = 0f;
    }
    public void HideMenu()
    {
        MenuUI.SetActive(false);
        Time.timeScale = 1f;
    }

    public void RestartLevel()
    {
        gameController.RestartLevel();
    }
}
