﻿using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy[] enemyPrefabs;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private float respawnRate = 10f;
    [SerializeField] private float initializeSpawnDelay;
    [SerializeField] private int totalNumberToSpawn;
    [SerializeField] private int numberToSpawnEachTime = 1;

    private float spawnTimer;
    private int totalNumberSpawned;

    private void OnEnable()
    {
        spawnTimer = respawnRate - initializeSpawnDelay;
    }

    private void Update()
    {
        spawnTimer += Time.deltaTime;

        if (ShouldSpawn())
            Spawn();
    }

    private void Spawn()
    {
        spawnTimer = 0;

        var availableSpawnPoints = spawnPoints.ToList();

        for (int i = 0; i < numberToSpawnEachTime; i++)
        {
            if (totalNumberToSpawn > 0 && totalNumberSpawned >= totalNumberToSpawn)
                break;

            Enemy prefab = ChooseRandomEnemyPrefab();
            if (prefab != null)
            {
                var spawnPoint = ChooseRandomSpawnPoint(availableSpawnPoints);

                if (availableSpawnPoints.Contains(spawnPoint))
                    availableSpawnPoints.Remove(spawnPoint);

                var enemy = prefab.Get<Enemy>(spawnPoint.position, spawnPoint.rotation);
                totalNumberSpawned++;
            }
        }
    }

    private bool ShouldSpawn()
    {
        if (totalNumberToSpawn > 0 && totalNumberSpawned >= totalNumberToSpawn)
            return false;

        return spawnTimer >= respawnRate;
    }

    private Enemy ChooseRandomEnemyPrefab()
    {
        if (enemyPrefabs.Length == 0)
            return null;

        if (enemyPrefabs.Length == 1)
            return enemyPrefabs[0];

        int index = UnityEngine.Random.Range(0, enemyPrefabs.Length);
        return enemyPrefabs[index];
    }

    private Transform ChooseRandomSpawnPoint(List<Transform> availableSpawnPoints)
    {
        if (availableSpawnPoints.Count == 0)
            return transform;

        if (availableSpawnPoints.Count == 1)
            return availableSpawnPoints[0];

        int index = UnityEngine.Random.Range(0, availableSpawnPoints.Count);
        return availableSpawnPoints[index];
    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawCube(transform.position, Vector3.one);

        foreach (var spawn in spawnPoints)
        {
            Gizmos.DrawSphere(spawn.position, 0.5f);
        }
    }


#endif
}
