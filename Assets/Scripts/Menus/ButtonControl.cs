using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ButtonControl : MonoBehaviour
{
    [SerializeField]
    GameObject lockIcon;
    [SerializeField]
    Button button;
    [SerializeField]
    TMP_Text textDisplay;

    int index;

    public void lockButton()
    {
        lockIcon.SetActive(true);
        button.interactable = false;
    }
    public void unlockButton()
    {
        lockIcon.SetActive(false);
        button.interactable = true;
    }

    public void setIndex(int buttonIndex)
    {
        index = buttonIndex;
        textDisplay.text = (buttonIndex + 1).ToString();
    }

    public void StartLevel()
    {
        ApplicationData.currentLevel = index;
        SceneManager.LoadScene("Level1");
    }
}
