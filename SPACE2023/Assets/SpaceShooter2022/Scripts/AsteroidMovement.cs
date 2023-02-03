using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMovement : MonoBehaviour
{
    [Header("Movement Speed")]
    public float maxSpeed;
    public float minSpeed;

    [Header("Rotation Speed")]
    public float maxRotationSpeed;
    public float minRotationSpeed;

    private float rotationSpeed;
    private float xAngle, yAngle, zAngle;

    public Vector3 movementDirection;
    private float asteroidSpeed;

    // Start is called before the first frame update
    void Start()
    {
        //get a random speed and rotation speed
        asteroidSpeed = Random.Range(minSpeed, maxSpeed);

        xAngle = Random.Range(0, 360);
        yAngle = Random.Range(0, 360);
        zAngle = Random.Range(0, 360);
        transform.Rotate(xAngle, yAngle, zAngle);
        rotationSpeed = Random.Range(minRotationSpeed, maxRotationSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(movementDirection * asteroidSpeed * Time.deltaTime, Space.World);
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
    }
}
