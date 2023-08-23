using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class rotationTower : MonoBehaviour
{

    [SerializeField]
    Transform rotationCenter;
  
    [SerializeField]
    float rotationRadius, angularSpeed;
    public GameObject lazer;
    float posX, posY, angle = 0f;

    public float leftLockAngle;
    public float rightLockAngle;
    public float rote;

    void Update()
    {
        if (angle < leftLockAngle)
        {
            if (Input.GetKey(KeyCode.Z))
            {

                angle = angle + Time.deltaTime * angularSpeed;
                transform.Rotate(0, 0, rote);
                if (angle >= leftLockAngle)
                {

                    transform.rotation = Quaternion.Euler(0, 0, 90);
                }
            }
        }

        if (angle > rightLockAngle)
        {
            if (Input.GetKey(KeyCode.X))
            {

                angle = angle + Time.deltaTime * -angularSpeed;
                transform.Rotate(0, 0, -rote);
                if (angle <= rightLockAngle)
                {
                    transform.rotation = Quaternion.Euler(0, 0, -90);
                }
            }
        }

        if (angle > 1.5 && angle < 1.6)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        posX = rotationCenter.position.x + Mathf.Cos(angle) * rotationRadius;
        posY = rotationCenter.position.y + Mathf.Sin(angle) * rotationRadius / 1.5f;


        transform.position = new Vector3(posX, posY);

       
        if (Input.GetKey(KeyCode.Space))
        {

        }

    }
}
