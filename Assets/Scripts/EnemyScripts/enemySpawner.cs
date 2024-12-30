using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemySpawner : MonoBehaviour
{

    public Transform enemyPrefab;

    public Transform spawnPoint;

    public float timeBetweenWaves = 5f;

    private float countDown = 2f;

    public Text waveCountDownText;

    private int waveNumber = 0;

    // Update is called once per frame
    void Update()
    {
        if (countDown <= 0f)
        {
            countDown = timeBetweenWaves;
            StartCoroutine(SpawnWave());
        }

        countDown -= Time.deltaTime;
        countDown = Mathf.Clamp(countDown, 0f, Mathf.Infinity);
        waveCountDownText.text = string.Format("{0:00.00}", countDown);
    }

    IEnumerator SpawnWave()
    {
        waveNumber++;

        for (int i = 0; i < waveNumber; i++)
        {
            SpawnEnemy(waveNumber * 10);
            yield return new WaitForSeconds(0.5f);
        }
    }

    void SpawnEnemy(int healthIncrement)
    {
        Transform enemyRef = Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
        Enemy e = enemyRef.GetComponent<Enemy>();
        e.health += healthIncrement;
    }
}
