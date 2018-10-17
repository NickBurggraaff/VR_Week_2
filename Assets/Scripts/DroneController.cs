using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneController : MonoBehaviour
{

    [SerializeField] private GameObject laser;
    [SerializeField] private float shootTimer;

    void Start()
    {
        ShootLaser();
    }

    private void ShootLaser() {
        Instantiate(laser, transform.position, Quaternion.identity);

        Invoke("ShootLaser", shootTimer);
    }
}
