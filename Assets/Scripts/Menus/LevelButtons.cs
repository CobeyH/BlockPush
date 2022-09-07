using UnityEngine;

public class LevelButtons : MonoBehaviour
{
    [SerializeField]
    GameController gameController;
    [SerializeField]
    GameObject buttonPrefab;
    // Start is called before the first frame update
    void Start()
    {
        int levelCount = gameController.GetComponent<ChunkSpawner>().GetLevelCount();
        int furthestLevel = PlayerPrefs.GetInt("progress", 0);
        for (int levelIndex = 0; levelIndex < levelCount; levelIndex++)
        {
            GameObject buttonObject = Instantiate(buttonPrefab, gameObject.transform);
            ButtonControl control = buttonObject.GetComponent<ButtonControl>();
            control.setIndex(levelIndex);
            if (levelIndex > furthestLevel)
            {
                control.lockButton();
            }
            else
            {

                control.unlockButton();
            }
        }
    }

}
