using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Skeleton _skeletonPrefab;

    public Transform GetTarget()
    {
        return _target;
    }

    public Skeleton GetSkeletonPrefab()
    {
        return _skeletonPrefab;
    }
}