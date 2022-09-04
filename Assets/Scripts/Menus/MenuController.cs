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
        Time.timeScale = 1f;
        MenuUI.SetActive(false);
    }

    public void RestartLevel()
    {
        gameController.RestartLevel();
    }
}
