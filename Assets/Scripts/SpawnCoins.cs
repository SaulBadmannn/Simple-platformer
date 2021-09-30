using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCoins : MonoBehaviour
{
    [SerializeField] private GameObject _coin;
    [SerializeField] private Transform _allSpawns;
    private Transform[] _spawns;

    void Start()
    {
        _spawns = new Transform[_allSpawns.childCount];

        for (int i = 0; i < _allSpawns.childCount; i++)
        {
            _spawns[i] = _allSpawns.GetChild(i);
            Vector3 spawnPoint = _spawns[i].position;
            Instantiate(_coin, spawnPoint, Quaternion.identity);
        } 
    }
}
