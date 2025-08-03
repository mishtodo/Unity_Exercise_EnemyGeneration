using UnityEngine;

public class SkeletonMover : MonoBehaviour 
{
    [SerializeField] private float _speed = 4.75f;
    
    public GameObject Target;

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, Target.transform.position, _speed * Time.deltaTime);
    }
}