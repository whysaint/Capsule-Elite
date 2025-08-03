using System;
using UnityEngine;

public class FolowCamera : MonoBehaviour
{
    public Transform target;

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, target.position, Time.deltaTime * 5f);
    }
}
