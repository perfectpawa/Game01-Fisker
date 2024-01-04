using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawner : MonoBehaviour
{
    [SerializeField] private List<Fish> _fishPrefabs;
    [Header("Pool")]
    [SerializeField] private List<Fish> _pool;

    private void Start()
    {
        _pool = new List<Fish>();
    }

    public Fish SpawnFish(Transform spawnPoint, Transform movePoint)
    {
        Fish fish = GetFishFromPool();
        if (fish == null)
        {
            fish = Instantiate(_fishPrefabs[Random.Range(0, _fishPrefabs.Count)], transform.position, Quaternion.identity);
        }
        fish.transform.position = spawnPoint.position;
        fish.SetMovePoint(movePoint.position);
        fish.gameObject.SetActive(true);
        return fish;
    }

    private Fish GetFishFromPool()
    {
        for (int i = 0; i < _pool.Count; i++)
        {
            if (!_pool[i].gameObject.activeSelf)
            {
                return _pool[i];
            }
        }
        return null;
    }

    public void ReturnFishToPool(Fish fish)
    {
        fish.gameObject.SetActive(false);
    }
}
