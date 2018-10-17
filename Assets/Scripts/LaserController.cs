using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserController : MonoBehaviour
{
    private Vector3 randomDirection;
    [SerializeField] private GameObject explosion;

    // Start is called before the first frame update
    void Start()
    {
        randomDirection = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, -1f), Random.Range(-1f, 1f));
        transform.Rotate(randomDirection);
    }

    private void Update() {
        transform.position += randomDirection;
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.layer == 9) {
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
