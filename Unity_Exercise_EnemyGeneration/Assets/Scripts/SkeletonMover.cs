using UnityEngine;

public class SkeletonMover : MonoBehaviour 
{
    [SerializeField] private float _speed = 4.75f;
    
    private Transform _target;

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);
    }

    public void InitializeTarget(Transform target)
    {
        _target = target;
    }
}