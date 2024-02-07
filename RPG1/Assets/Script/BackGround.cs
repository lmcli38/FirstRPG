using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    GameObject cam;
    [SerializeField] float parallaxEffect;
    float xPosition;
    void Start()
    {
        cam = GameObject.Find("Main Camera");

        xPosition = transform.position.x;
    }
    void Update()
    {
        float distanceToMove = cam.transform.position.x * parallaxEffect;

        transform.position = new Vector3(xPosition + distanceToMove, transform.position.y);
    }
}

