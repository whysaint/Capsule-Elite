using System;
using UnityEngine;

public class Pointer : MonoBehaviour
{
    public Transform Aim;
    public Camera Camera;

    private void Update()
    {
        Debug.Log(Input.mousePosition);

        Ray Ray = Camera.ScreenPointToRay(Input.mousePosition);
        
        Debug.DrawRay(Ray.origin, Ray.direction * 50, Color.green);

        Plane plane = new Plane(-Vector3.forward, Vector3.zero);

        float distance;
        plane.Raycast(Ray, out distance);
        Vector3 point = Ray.GetPoint(distance);

        Aim.position = point;

        Vector3 toAim = Aim.position - transform.position;
        transform.rotation = Quaternion.LookRotation(toAim);
    }
}
