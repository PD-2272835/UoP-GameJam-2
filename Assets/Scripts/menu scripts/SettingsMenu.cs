using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;

    public TMPro.TMP_Dropdown resolutionDropdown;

    Resolution[] resolutions;

    void Start() 
    { 
        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();  // clear out options in resolution dropdown box 

        List<string> options = new List<string>();   // creates a list of strings for our new resolution options

        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)   // we loop through each 'element' in our resolutions array
        {
            string option = resolutions[i].width + " x " + resolutions[i].height + " @ " + resolutions[i].refreshRate + " Hz";
            options.Add(option); // before adding it to our options list

            /*if (resolutions[i].width == Screen.width && resolutions[i].height == Screen.height)
            {
                currentResolutionIndex = i;
            } 
            */

            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }
        resolutionDropdown.AddOptions(options); // once the loop is complete we'll add the list to our resolutions dropdown box
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    public void SetResolution (int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
    }

    public void SetFullscreen (bool IsFullscreen)
    {
        Screen.fullScreen = IsFullscreen;
    }
}
