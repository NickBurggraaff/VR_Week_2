using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneController : MonoBehaviour
{

    [SerializeField] private GameObject laser;

    void Start()
    {
        ShootLaser();
    }

    private void ShootLaser() {
        Instantiate(laser, transform.position, Quaternion.identity);

        Invoke("ShootLaser", 3);
    }
}
