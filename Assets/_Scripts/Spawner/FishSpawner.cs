using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawner : MonoBehaviour
{
    [SerializeField] private List<Fish> _fishPrefabs;
    [SerializeField] private Transform _fishHolder;
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
            int ran = Random.Range(0, _fishPrefabs.Count * 2);
            if (ran >= _fishPrefabs.Count)
            {
                ran = 0;
            }
            Fish fishPrefab = _fishPrefabs[ran];
            fish = Instantiate(fishPrefab, spawnPoint.position, Quaternion.identity, _fishHolder);
            fish.gameObject.name = "Fish-" + _pool.Count;
            _pool.Add(fish);
        }
        fish.transform.position = spawnPoint.position;
        fish.SetMovePoint(movePoint);
        fish.gameObject.SetActive(true);
        return fish;
    }

    private Fish GetFishFromPool()
    {
        for (int i = 0; i < _pool.Count; i++)
        {
            if (!_pool[i].isActiveAndEnabled)
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
