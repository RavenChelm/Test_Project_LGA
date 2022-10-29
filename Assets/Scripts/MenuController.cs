using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;
public class MenuController : MonoBehaviour
{
    public AudioMixer am;
    [SerializeField] Slider slider;
    private Game gm = new Game();
    private void Awake()
    {
        HelpVolume();
    }
    public void MenuOn(GameObject obj)
    {
        obj.SetActive(true);
    }
    public void MenuOff(GameObject obj)
    {
        obj.SetActive(false);
    }
    public void SceneGame()
    {
        SceneManager.LoadScene("Game");
        HelpVolume();
    }
    public void SceneMenu()
    {
        SceneManager.LoadScene("Menu");
        HelpVolume();
    }
    public void ExitAplication()
    {
        Application.Quit();
    }
    public void SwitchVolume(float sliderValue)
    {
        am.SetFloat("masterVolume", sliderValue);
        Game.current.InputVolume(sliderValue);
        SaveLoad.Save();

    }
    private void HelpVolume()
    {
        am.SetFloat("masterVolume", Game.current.volume);
        SaveLoad.Load();
        if (SaveLoad.savedGames.Count > 0)
            slider.value = SaveLoad.savedGames[0].volume;
    }

}
