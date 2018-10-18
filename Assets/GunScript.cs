using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
    public GameObject TurretComplete;
    public GameObject TurretBase;
    public GameObject TurretGun;
    [SerializeField] public List<Color> ColorCollection;

    // Start is called before the first frame update
    void Start()
    {
        CurrentCooldown = ShootCooldown;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && PlayerInTurret)
        {
            PlayerInTurret = false;
            Robot.GetComponent<SkinnedMeshRenderer>().enabled = true;
            Player.GetComponent<VRwalk>().enabled = true;
            Player.transform.position = Spawn.position;

            Player = null;
            Robot = null;
            PlayerCamera = null;
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
        Robot.GetComponent<SkinnedMeshRenderer>().enabled = false;
    }

    private void Shoot()
    {
        GameObject go = Instantiate(ProjectilePrefab, PlayerCamera.transform.position, PlayerCamera.transform.rotation);
        List<TrailRenderer> renderers = new List<TrailRenderer>();
        renderers = go.GetComponentsInChildren<TrailRenderer>().ToList();
        int index = Random.Range(0, ColorCollection.Count);
        foreach (var r in renderers)
        {
            r.startColor = ColorCollection[index];
            r.endColor = ColorCollection[index];
        }
        Destroy(go, 10);
    }
}
