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

    void start () 
    { 
        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();  // clear out options in resolution dropdown box 

        List<string> options = new List<string>();   // creates a list of strings for our new resolution options

        for (int i = 0; i < resolutions.Length; i++)   // we loop through each 'element' in our resolutions array
        {
            string option = resolutions[i].width + " x " + resolutions[i].height + " @ " + resolutions[i].refreshRate + " Hz";
            options.Add(option); // before adding it to our options list
        }

        resolutionDropdown.AddOptions(options); // once the loop is complete we'll add the list to our resolutions dropdown box
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
