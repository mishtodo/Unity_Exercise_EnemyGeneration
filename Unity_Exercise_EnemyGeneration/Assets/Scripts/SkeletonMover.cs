using UnityEngine;

public class SkeletonMover : MonoBehaviour 
{
    [SerializeField] private float _speed = 4.75f;
    
    private GameObject _target;

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target.transform.position, _speed * Time.deltaTime);
    }

    public void InitializeTarget(GameObject target)
    {
        _target = target;
    }
}