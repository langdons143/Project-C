using UnityEngine;
using System.Collections;

public class TargetSpawner : MonoBehaviour
{
    public GameObject normalTarget;
    public GameObject rareTarget;

    public Transform spawnArea;

    public float spawnWidth = 10f;
    public float spawnHeight = 5f;

    public float spawnInterval = 1.5f;

    [Range(0f, 1f)]
    public float rareTargetChance = 0.15f;

    private void Start()
    {
        StartCoroutine(SpawnTargets());
    }

    private IEnumerator SpawnTargets()
    {
        while (!GameTimer.instance.gameEnded)
        {
            SpawnTarget();

            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private void SpawnTarget()
    {
        float randomX = Random.Range(-spawnWidth / 2f, spawnWidth / 2f);
        float randomY = Random.Range(-spawnHeight / 2f, spawnHeight / 2f);

        Vector3 spawnPosition = spawnArea.position +
            spawnArea.right * randomX +
            spawnArea.up * randomY;

        GameObject targetToSpawn;

        if (Random.value < rareTargetChance)
        {
            targetToSpawn = rareTarget;
        }
        else
        {
            targetToSpawn = normalTarget;
        }

Instantiate(targetToSpawn, spawnPosition, targetToSpawn.transform.rotation);    }
}