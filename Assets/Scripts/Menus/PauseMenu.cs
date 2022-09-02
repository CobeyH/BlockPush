using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    MenuController menuController;
    // Start is called before the first frame update
    void Start()
    {
        menuController = gameObject.GetComponent<MenuController>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            bool isGamePaused = menuController.MenuUI.activeSelf;
            Debug.Log(isGamePaused);
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
}