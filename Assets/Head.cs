using UnityEngine;

public class Head : MonoBehaviour
{
    public Transform target;
    void Update()
    {
        transform.position = target.position;
    }
}
