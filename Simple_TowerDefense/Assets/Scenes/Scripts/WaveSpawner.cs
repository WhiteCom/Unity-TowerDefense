using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    //every time when enemy die to be able to change this value for new enemy
    public static int EnemiesAlives = 0;

    public Wave[] waves;

    public Transform spawnPoint;
    public Transform spawnPoint2;
    public Transform spawnPoint3;
    public Transform spawnPoint4;

    public float timeBetweenWaves = 5f; //스폰간격
    private float countdown = 2f;

    public Text waveCountdownText;

    public GameManager gameManager;
    [SerializeField]
    private int waveIndex = 0;

    public GameObject gameOverUI;

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

        if (waveIndex == waves.Length && EnemiesAlives <= 0 && !gameOverUI.activeInHierarchy)
        {
            gameManager.WinLevel();
            this.enabled = false;
        }

        if (gameOverUI.activeInHierarchy)
        {
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

        //2군데 이상 스폰 시 이 부분 잘 파악
        if(spawnPoint != null && spawnPoint2 == null && spawnPoint3 == null && spawnPoint4 == null)
            EnemiesAlives = wave.count;
        else if(spawnPoint != null && spawnPoint2 != null && spawnPoint3 == null && spawnPoint4 == null)
            EnemiesAlives = wave.count * 2;
        else if (spawnPoint != null && spawnPoint2 != null && spawnPoint3 != null && spawnPoint4 == null)
            EnemiesAlives = wave.count * 3;
        else if (spawnPoint != null && spawnPoint2 != null && spawnPoint3 != null && spawnPoint4 != null)
            EnemiesAlives = wave.count * 4;

        for (int i = 0; i < wave.count; i++)
        {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1f / wave.rate); 
        }
        waveIndex++;
    }
    
    void SpawnEnemy(GameObject enemy)
    {
        if(spawnPoint != null)
            Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
        if(spawnPoint2 != null)
            Instantiate(enemy, spawnPoint2.position, spawnPoint2.rotation);
        if (spawnPoint3 != null)
            Instantiate(enemy, spawnPoint3.position, spawnPoint3.rotation);
        if (spawnPoint4 != null)
            Instantiate(enemy, spawnPoint4.position, spawnPoint4.rotation);
    }

    public int WaveIndex()
    {
        return waveIndex;
    }
}
