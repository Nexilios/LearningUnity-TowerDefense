using System.Collections;
using System.Globalization;
using TMPro;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefab;
    public Transform spawnPoint;
    public TextMeshProUGUI waveCountText;
    
    public float timeBetweenSpawns = 5f;
    private float _countdown = 3f;

    private int _waveIndex;
    private void Update()
    {
        if (_countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            _countdown = timeBetweenSpawns;
        }
        
        waveCountText.text = Mathf.Ceil(_countdown).ToString(CultureInfo.CurrentCulture);
        _countdown -= Time.deltaTime;
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
