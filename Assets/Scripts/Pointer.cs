using System;
using UnityEngine;

public class Pointer : MonoBehaviour
{
    public Transform Aim;
    public Camera Camera;
    public Transform Body;

    private float _yEular;

    private void LateUpdate()
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

        if (toAim.x < 0)
        {
            _yEular = Mathf.Lerp(_yEular, 45f, Time.deltaTime * 10f);
        }
        else
        {
            _yEular = Mathf.Lerp(_yEular, -45f, Time.deltaTime * 10f);
        }

        Body.localEulerAngles = new Vector3(0f, _yEular, 0f);
    }
}
