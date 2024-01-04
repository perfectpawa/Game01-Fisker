using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private FishSpawner _fishSpawner;
    [SerializeField] private List<Transform> _spawnPoints;
    [SerializeField] private List<Transform> _leftMovePoints;
    [SerializeField] private List<Transform> _rightMovePoints;
    [SerializeField] private float _spawnDelay = 1f;

    private float timer;

    private void Start()
    {
        timer = 0;
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= _spawnDelay)
        {
            timer = 0;
            Transform spawnPoint = _spawnPoints[Random.Range(0, _spawnPoints.Count)];
            Transform movePoint;
            if(spawnPoint.position.x < 0)
            {   
                movePoint = _rightMovePoints[Random.Range(0, _rightMovePoints.Count)];
            }
            else
            {
                movePoint = _leftMovePoints[Random.Range(0, _leftMovePoints.Count)];
            }
            Fish newFish = _fishSpawner.SpawnFish(spawnPoint, movePoint);
        }
    }


}
