using UnityEngine;

public class TargetMover : MonoBehaviour
{
    [SerializeField] private float _speed = 2.75f;
    [SerializeField] private Transform[] _targetWayPoints;

    private int _currentWayPoint = 0;

    private void Update()   
    {
        if (transform.position == _targetWayPoints[_currentWayPoint].transform.position)
        {
            _currentWayPoint = (_currentWayPoint + 1) % _targetWayPoints.Length;
        }

        transform.position = Vector3.MoveTowards(transform.position, _targetWayPoints[_currentWayPoint].position, _speed * Time.deltaTime);
    }
}