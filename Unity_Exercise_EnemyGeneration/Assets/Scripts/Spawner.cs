using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _spawnPoints;
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
            SpawnPoint spawnPoint = GetRandomSpawnPoint();
            enemySkeleton = Instantiate<Skeleton>(spawnPoint.GetSkeletonPrefab(), spawnPoint.transform.position, spawnPoint.transform.rotation, spawnPoint.transform);
            enemySkeleton.Dying += DestroySkeleton;
            enemySkeleton.SkeletonMover.InitializeTarget(spawnPoint.GetTarget());

            yield return wait;
        }
    }

    private void DestroySkeleton(Skeleton skeleton)
    {
        skeleton.Dying -= DestroySkeleton;
        Destroy(skeleton.gameObject);
    }

    private SpawnPoint GetRandomSpawnPoint()
    {
        int minSpawnPoint = 0;
        int maxSpawnPoint = _spawnPoints.Length;

        if (_spawnPoints[Random.Range(minSpawnPoint, maxSpawnPoint)].TryGetComponent<SpawnPoint>(out SpawnPoint spawnPoint))
            return spawnPoint;
        else 
            return null;
    }
}