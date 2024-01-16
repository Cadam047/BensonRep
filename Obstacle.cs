using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.Video;

public class Obstacle : MonoBehaviour
{

    private float leftEdge;

    private void Start() 
    {

        leftEdge = Camera.main.ScreenToWorldPoint(UnityEngine.Vector3.zero).x - 2f;

    }

    private void Update() {

        transform.position += UnityEngine.Vector3.left * GameManager.Instance.gameSpeed * Time.deltaTime;

        if (transform.position.x < leftEdge) {

            Destroy(gameObject);

        }

    }
}
