using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultySelect : MonoBehaviour
{
    public string Normal = "Normal";
    public string Hard = "Hard";

    public SceneFader sceneFader;

    public void Play_Normal()
    {
        FindObjectOfType<SceneFader>().FadeTo(Normal);
    }

    public void Play_Hard()
    {
        FindObjectOfType<SceneFader>().FadeTo(Hard);
    }

}
