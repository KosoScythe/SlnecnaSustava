using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovements : MonoBehaviour
{
    public float initialSpeed = 2.0f;
    public float acceleration = 1.0f; 

    public float minTilt = -70.0f;
    public float maxTilt = 70.0f;

    public float sensHorizontal = 300.0f;
    public float sensVertical = 300.0f;

	float rotationY = 0.0f;
    float rotationX = 0.0f;

    float speed = 0.0f;
    bool wasMoved = false;

    void Move(Vector3 direction)
    {
        transform.position += direction * speed * Time.deltaTime;
        wasMoved = true;
    }

    void Start()
    {
        speed = initialSpeed;

        rotationX = transform.localEulerAngles.x;
        rotationY = transform.localEulerAngles.y;
    }

    void Update ()
    {
        if (Input.GetMouseButton(1))
        {
            if (Input.GetKey(KeyCode.D))
            {
                Move(transform.right);
            }
            if (Input.GetKey(KeyCode.A))
            {
                Move(-transform.right);
            }
            if (Input.GetKey(KeyCode.W))
            {
                Move(transform.forward);
            }
            if (Input.GetKey(KeyCode.S))
            {
                Move(-transform.forward);
            }
            if (Input.GetKey(KeyCode.E))
            {
                Move(transform.up);
            }
            if (Input.GetKey(KeyCode.Q))
            {
                Move(-transform.up);
            }

            rotationY += Input.GetAxis("Mouse X") * sensHorizontal * Time.deltaTime;
            rotationX -= Input.GetAxis("Mouse Y") * sensVertical * Time.deltaTime;
            rotationX = Mathf.Clamp (rotationX, minTilt, maxTilt);
			transform.localEulerAngles = new Vector3 (rotationX, rotationY, 0);

            if (!wasMoved)
            {
                speed = initialSpeed;
            }
            else
            {
                speed += acceleration * Time.deltaTime;
            }
            wasMoved = false;
		}
	}
}
