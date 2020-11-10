using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveUI : MonoBehaviour
{
    public Text WaveText;
    public WaveSpawner temp_waves;
    int _waves;
    int _wave;

    // Update is called once per frame
    void Update()
    {
        _wave = PlayerStats.Rounds;
        _waves = temp_waves.waves.Length;
        WaveText.text = " Wave : " + _wave + " / " + _waves;
    }
}
