using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test1 : MonoBehaviour
{
    public GameObject lazer;
    public Transform lazerpos;
    public Transform Tower;
    void Start()
    {
      Tower = GetComponentInParent<Transform>();
       
    }

    // Update is called once per frame
    void Update()
    {
        lazerpos.rotation = Tower.rotation;
        if (Input.GetKey(KeyCode.Space))
        {
           
                Instantiate(lazer, lazerpos.position, Quaternion.Euler(0, 0, - 90));
        }
    }
}
