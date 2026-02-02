using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;
using Unity.VisualScripting;
using System;
using TMPro;

public class MainMenu : MonoBehaviour
{
    [SerializeField]public AudioMixer AudioMixer;
    [SerializeField]private Slider slider;
    [SerializeField] decimal sens;//sensitiviti
    [SerializeField] public TextMeshProUGUI text;
   
    

    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("radi");
    }

    public void SetVolume(float volume)
    {
        Debug.Log(volume);
        AudioMixer.SetFloat("Volume", volume);
    }

    public void Fullscreen(bool fullscreen)
    {
        Screen.fullScreen = fullscreen;
    }

    public void snesitivity()
    {
        sens = (decimal)slider.value;
        Debug.Log($"{sens}");
        text.text = $"Sensitivty: {sens:F2}";
    }
}
