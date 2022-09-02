using UnityEngine;

public class MenuController : MonoBehaviour
{
    public GameObject MenuUI;
    public GameController gameController;

    void Start()
    {
        gameController = FindObjectOfType<GameController>();
    }

    public void ShowMenu()
    {
        MenuUI.SetActive(true);
    }
    public void HideMenu()
    {
        MenuUI.SetActive(false);
    }

    public void RestartLevel()
    {
        gameController.RestartLevel();
    }
}
