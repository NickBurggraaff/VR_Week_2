using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketController : MonoBehaviour
{
    private Vector3 StartPosition;
    private float Speed;
    private bool Fire;
    private float ShootCooldown;

    // Start is called before the first frame update
    void Start()
    {
        StartPosition = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        ShootCooldown -= Time.deltaTime;
        if (ShootCooldown < 0)
        {
            ShootCooldown = 0;
            if (Fire)
            {
                transform.Translate(Vector3.back * Time.deltaTime * Speed);
            }
        }
    }

    public void Shoot(float speed, float cooldown)
    {
        ShootCooldown = cooldown;
        Speed = speed;
        if (Fire)
        {
            transform.localPosition = StartPosition;
        }
        else
        {
            Fire = true;
        }
        
    }
}
