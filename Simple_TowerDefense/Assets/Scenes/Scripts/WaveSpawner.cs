using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    //every time when enemy die to be able to change this value for new enemy
    public static int EnemiesAlives = 0;

    public Wave[] waves;

    public Transform spawnPoint;

    public float timeBetweenWaves = 5f; //스폰간격
    private float countdown = 2f;

    public Text waveCountdownText;

    public GameManager gameManager;
    private int waveIndex = 0;

    void Start()
    {
        EnemiesAlives = 0;    
    }
    void Update()
    {
        if (EnemiesAlives > 0)
        {
            return;
        }

        if (waveIndex == waves.Length)
        {
            gameManager.WinLevel();
            this.enabled = false;
        }

        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
            return;
        }

        countdown -= Time.deltaTime;

        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

        waveCountdownText.text = "Next Wave : " + string.Format("{0:0.00}", countdown);
    }
    
    IEnumerator SpawnWave()
    {
        PlayerStats.Rounds++;

        //initial waveIndex is zero
        Wave wave = waves[waveIndex];

        EnemiesAlives = wave.count;

        for (int i = 0; i < wave.count; i++)
        {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1f / wave.rate); //half second
        }
        waveIndex++;
    }
    
    void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
    }
}
