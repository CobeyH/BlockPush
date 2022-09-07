using UnityEngine;
using UnityEngine.UI;

public class LockControl : MonoBehaviour
{
    [SerializeField]
    GameObject lockIcon;
    [SerializeField]
    Button button;

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
}
