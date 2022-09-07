using UnityEngine;
using UnityEngine.UI;

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
            LockControl control = buttonObject.GetComponent<LockControl>();
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

    // Update is called once per frame
    void Update()
    {

    }
}
