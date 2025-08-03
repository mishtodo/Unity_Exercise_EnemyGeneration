using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private GameObject _target;
    [SerializeField] private Skeleton _skeletonPrefab;

    public GameObject GetTarget()
    {
        return _target;
    }

    public Skeleton GetSkeletonPrefab()
    {
        return _skeletonPrefab;
    }
}