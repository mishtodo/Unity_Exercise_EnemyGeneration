using System;
using UnityEngine;

public class Skeleton : MonoBehaviour 
{
    public event Action<Skeleton> Dying;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<DyingZone>(out DyingZone dyingZone))
            Dying?.Invoke(this);
    }
}
