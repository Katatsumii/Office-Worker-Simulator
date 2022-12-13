using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;


public class SettingsPauseMenu : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown resolutionDropdown;
    private Resolution[] resolutions;
    private List<Resolution> filteredREsolutions;
    private float currentRefreshRate;
    private int currentResolutionIndex = 0;
    public enum Quality
    {
        low,
        medium,
        high
    }
    public Quality currentQuality;
    [SerializeField]
    private AudioMixer audioMixer;
    [SerializeField]
    private AudioMixer musicMixer;
    [SerializeField]
    private Image buttonLow, buttonHigh, buttonMedium;
    [SerializeField]
    private Sprite buttonLowSprite, buttonHighSprite, buttonMediumSprite;
    [SerializeField]
    private Sprite buttonLowSpriteSelected,buttonHighSpriteSelected,buttonMediumSpriteSelected;

    private void Start()
    {
        currentQuality = Quality.high;
        resolutions = Screen.resolutions;
        filteredREsolutions= new List<Resolution>();
        resolutionDropdown.ClearOptions();
        currentRefreshRate = Screen.currentResolution.refreshRate;

        for(int i=0;i<resolutions.Length;i++)
        {
            if (resolutions[i].refreshRate==currentRefreshRate)
            {
                filteredREsolutions.Add(resolutions[i]);
            }
        }
        List<string> options=new List<string>();
        for(int i=0;i<filteredREsolutions.Count;i++)
        {
            string resolutionOption = filteredREsolutions[i].width + "x" + filteredREsolutions[i].height +" "+ filteredREsolutions[i].refreshRate+"Hz";
            options.Add(resolutionOption);
            if (filteredREsolutions[i].width == Screen.width && filteredREsolutions[i].height==Screen.height)
            {
                currentResolutionIndex = i;
            }
        }
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = filteredREsolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, true);
    }
    public void SetVolumeAudio(float audiovolume)
    {
        audioMixer.SetFloat("audioVolume", audiovolume);
    }
    public void SetVolumeMusic(float musicvolume)
    {
        musicMixer.SetFloat("musicVolume",musicvolume);
    }
  
    public void ButtonLow()
    {
        QualitySettings.SetQualityLevel(0);
        currentQuality = Quality.low;
    }
    public void ButtonMedium()
    {
        QualitySettings.SetQualityLevel(1);
        currentQuality = Quality.medium;
    }
    public void ButtonHigh()
    {
        QualitySettings.SetQualityLevel(2);
        currentQuality = Quality.high;
    }
    public void SetFullscreen(bool fullscreen)
    {
        Screen.fullScreen = fullscreen;
    }
    private void Update()
    {
        switch(currentQuality)
        {

         case Quality.low:
                buttonLow.sprite = buttonLowSpriteSelected; buttonHigh.sprite = buttonHighSprite; buttonMedium.sprite = buttonMediumSprite;
            break;
        case Quality.medium:
                buttonLow.sprite = buttonLowSprite; buttonHigh.sprite = buttonHighSprite; buttonMedium.sprite = buttonMediumSpriteSelected;
                break;
        case Quality.high:
                buttonLow.sprite = buttonLowSprite; buttonHigh.sprite = buttonHighSpriteSelected; buttonMedium.sprite = buttonMediumSprite;
                break;
        }

    }
}
