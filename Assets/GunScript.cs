using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    private bool PlayerInTurret;
    private float CurrentCooldown;
    private GameObject Player;
    private GameObject Robot;
    private GameObject PlayerCamera;

    public float ShootCooldown = 2f;
    public GameObject ProjectilePrefab;
    public Transform Spawn;

    // Start is called before the first frame update
    void Start()
    {
        CurrentCooldown = ShootCooldown;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            PlayerInTurret = false;
            Robot.SetActive(true);
            Player.GetComponent<VRwalk>().enabled = true;
            Player.transform.position = Spawn.position;

            Player = null;
            Robot = null;
            PlayerCamera = null;
        }

        if (PlayerInTurret)
        {
            transform.eulerAngles = new Vector3(PlayerCamera.transform.eulerAngles.x, 0, PlayerCamera.transform.eulerAngles.z);
        }

        CurrentCooldown -= Time.deltaTime;
        if (PlayerInTurret && CurrentCooldown < 0)
        {
            CurrentCooldown = ShootCooldown;
            Shoot();
        }
    }

    public void UseTurret()
    {
        PlayerInTurret = true;
        Player = GameObject.FindGameObjectWithTag("Player");
        Player.GetComponent<VRwalk>().enabled = false;
        Robot = GameObject.FindGameObjectWithTag("Robot");
        PlayerCamera = GameObject.FindGameObjectWithTag("MainCamera");
        Player.transform.position = transform.position;
        Robot.SetActive(false);
    }

    private void Shoot()
    {
        GameObject go = Instantiate(ProjectilePrefab, transform.position, PlayerCamera.transform.localRotation);
        Destroy(go, 10);
    }
}
