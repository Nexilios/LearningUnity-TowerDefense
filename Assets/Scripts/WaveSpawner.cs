using System.Collections;
using TMPro;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public static int enemiesAlive;

    public Wave[] waves;
    public Transform spawnPoint;
    public TextMeshProUGUI waveCountText;
    
    public float timeBetweenWave = 5f;
    private float _countdown = 3f;

    private int _waveIndex;
    private void Update()
    {
        if (enemiesAlive > 0 || GameManager.GameIsOver) 
            return;
        
        if (_countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            _countdown = timeBetweenWave;
            return;
        }
        
        waveCountText.text = $"{_countdown:00.00}";
        
        _countdown = Mathf.Clamp(_countdown - Time.deltaTime, 0f, Mathf.Infinity);
    }

    IEnumerator SpawnWave()
    {
        PlayerStats.Rounds++;
        
        Wave wave = waves[_waveIndex];
        
        for (int i = 0; i < wave.enemyCount; i++)
        {
            SpawnEnemy(wave.enemyPrefab);
            yield return new WaitForSeconds(1f / wave.spawnRate);
        }
        
        _waveIndex++;

        if (_waveIndex == waves.Length)
        {
            Debug.Log("LEVEL WON!");
            this.enabled = false;
        }
    }

    void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
        enemiesAlive++;
    }
}
