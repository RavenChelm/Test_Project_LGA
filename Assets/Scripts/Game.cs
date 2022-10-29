using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Game
{
    public static Game current;
    public float volume = 0;

    public Game()
    {
        volume = 0;
        current = this;
    }
    public void InputVolume(float value)
    {
        current.volume = value;
    }

}