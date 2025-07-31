using UnityEngine;

public class SkeletonMover : MonoBehaviour 
{
    [SerializeField] private float _speed = 4.75f;

    public Vector3 Direction { get; private set; }

    private void Update()
    {
        transform.Translate(Direction * _speed * Time.deltaTime);
    }

    public void InitializeDirection(Vector3 direction)
    {
        Direction = direction;
    }
}