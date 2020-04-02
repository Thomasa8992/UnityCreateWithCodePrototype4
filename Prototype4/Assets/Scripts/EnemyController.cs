using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Rigidbody enemyRigidBody;
    private GameObject player;
    private float movementSpeed = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        enemyRigidBody = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        var lookDirection = (player.transform.position - transform.position).normalized;

        enemyRigidBody.AddForce(lookDirection * movementSpeed);
    }
}
