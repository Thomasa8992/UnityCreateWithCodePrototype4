using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed = 5.0f;

    private  Rigidbody playerRigidBody;

    private GameObject focalPoint;

    public GameObject powerupIndicator;
    public bool hasPowerUp;
    public float powerupStrength = 15.0f;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
    }

    // Update is called once per frame
    void Update()
    {
        var verticalInput = Input.GetAxis("Vertical");

        playerRigidBody.AddForce(focalPoint.transform.forward * verticalInput * movementSpeed);

        powerupIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Powerup")) {
            hasPowerUp = true;
            powerupIndicator.SetActive(true);

            Destroy(other.gameObject);

            StartCoroutine(PowerupCountdownRoutine());
        }
    }

    IEnumerator PowerupCountdownRoutine() {
        yield return new WaitForSeconds(7);

        hasPowerUp = false;
        powerupIndicator.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.CompareTag("Enemy") && hasPowerUp) {
            var enemyRigidBody = collision.gameObject.GetComponent<Rigidbody>();
            var enemyCurrentPosition = collision.gameObject.transform.position - transform.position;
            var calculatedPowerupKnockbackForce = enemyCurrentPosition * powerupStrength;

            enemyRigidBody.AddForce(calculatedPowerupKnockbackForce, ForceMode.Impulse);
        }
    }
}
