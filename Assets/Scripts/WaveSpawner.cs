using System.Collections;
using System.Globalization;
using TMPro;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefab;
    public Transform spawnPoint;
    public TextMeshProUGUI waveCountText;
    
    public float timeBetweenWave = 5f;
    private float _countdown = 3f;

    private int _waveIndex;
    private void Update()
    {
        if (_countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            _countdown = timeBetweenWave;
        }
        
        waveCountText.text = $"{_countdown:00.00}";
        
        _countdown = Mathf.Clamp(_countdown - Time.deltaTime, 0f, Mathf.Infinity);
    }

    IEnumerator SpawnWave()
    {
        _waveIndex++;
        for (int i = 0; i < _waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.25f);
        }
        
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
