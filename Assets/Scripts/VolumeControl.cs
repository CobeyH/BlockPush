using UnityEngine;
using UnityEngine.UI;
using Unity.VectorGraphics;

public class VolumeControl : MonoBehaviour
{
    [SerializeField]
    SVGImage ButtonIcon;
    [SerializeField]
    Slider volumeSlider;
    [SerializeField]
    Sprite PlayIcon;
    [SerializeField]
    Sprite PauseIcon;
    bool mute = false;
    float prevVolume = 1;

    AudioManager audioManager;

    void Start()
    {
        audioManager = GameObject.FindObjectOfType<AudioManager>();
        float restoredVolume = PlayerPrefs.GetFloat("Volume", 1f);
        volumeSlider.value = restoredVolume;
    }

    void Update()
    {
        float setVolume = volumeSlider.value;
        if (prevVolume != setVolume)
        {
            audioManager.SetVolume(setVolume);
            prevVolume = setVolume;
        }
    }

    public void ToggleMute()
    {
        mute = !mute;
        audioManager.SetVolume(mute ? 0.001f : 1f);
        volumeSlider.interactable = !mute;
        ButtonIcon.sprite = mute ? PlayIcon : PauseIcon;
    }
}
