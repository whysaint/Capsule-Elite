using System;
using UnityEngine;
using UnityEngine.InputSystem;
using Random = UnityEngine.Random;

public class Gun : MonoBehaviour
{
    public GameObject BulletPrefab;
    public Transform Spawn;
    public float BulletSpeed = 10f;
    public float ShotPeriod = 0.2f;
    public AudioSource ShotSound;
    public GameObject Flash;

    private float _timer;
    
    private void Update()
    {
        _timer += Time.deltaTime;

        if (_timer > ShotPeriod)
        {
            if (Input.GetMouseButton(0))
            {
                _timer = 0f;
                GameObject newBullet = Instantiate(BulletPrefab, Spawn.position, transform.rotation);
                newBullet.GetComponent<Rigidbody>().linearVelocity = Spawn.forward * BulletSpeed;
                ShotSound.pitch = Random.Range(0.8f, 1.2f);
                ShotSound.Play();
                Flash.SetActive(true);
                Invoke("HideFlash", 0.12f);
            }
        }
        
    }

    public void HideFlash()
    {
        Flash.SetActive(false);
    }
}
