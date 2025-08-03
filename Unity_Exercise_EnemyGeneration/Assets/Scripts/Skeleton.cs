using System;
using UnityEngine;

[RequireComponent(typeof(SkeletonMover))]
public class Skeleton : MonoBehaviour 
{
    public SkeletonMover SkeletonMover { get; private set; }
    public event Action<Skeleton> Dying;

    private void Awake()
    {
        SkeletonMover = GetComponent<SkeletonMover>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<DyingZone>(out DyingZone dyingZone))
            Dying?.Invoke(this);
    }
}