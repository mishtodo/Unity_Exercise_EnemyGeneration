using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _spawnPoints;
    [SerializeField] private Skeleton _skeletonPrefab;
    [SerializeField] private float _spawnRate = 1.0f;

    private Coroutine _coroutine;

    private void Start()
    {
        RestartCoroutine();
    }

    private void RestartCoroutine()
    {
        _coroutine = StartCoroutine(SpawnRepeated());
    }

    public void StopCoroutine()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);
    }

    private IEnumerator SpawnRepeated()
    {
        var wait = new WaitForSecondsRealtime(_spawnRate);
        Skeleton enemySkeleton;

        while (enabled) 
        {
            GameObject spawnPoint = GetRandomSpawnPoint();
            enemySkeleton = Instantiate<Skeleton>(_skeletonPrefab, spawnPoint.transform.position, spawnPoint.transform.rotation, spawnPoint.transform);
            enemySkeleton.Dying += DestroySkeleton;
            enemySkeleton.SkeletonMover.InitializeDirection(Vector3.forward);

            yield return wait;
        }
    }

    private void DestroySkeleton(Skeleton skeleton)
    {
        skeleton.Dying -= DestroySkeleton;
        Destroy(skeleton.gameObject);
    }

    private GameObject GetRandomSpawnPoint()
    {
        int minSpawnPoint = 0;
        int maxSpawnPoint = _spawnPoints.Length;

        return _spawnPoints[Random.Range(minSpawnPoint, maxSpawnPoint)];
    }
}