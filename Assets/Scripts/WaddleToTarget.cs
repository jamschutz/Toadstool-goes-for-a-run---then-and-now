using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaddleToTarget : MonoBehaviour
{
    public Transform target;
    public float waddleTime;
    public float speed;


    private float timer;
    private bool waddleLeft;
    private Vector3 waddleLeftRot;
    private Vector3 waddleRightRot;

    private void Start()
    {
        timer = 0;
        waddleLeft = true;

        waddleLeftRot = new Vector3(0, 0, -8);
        waddleRightRot = new Vector3(0, 0, 8);
    }


    private void Update()
    {
        if(!Input.GetKey(KeyCode.Space)) {
            return;
        }

        timer += Time.deltaTime;
        if(timer > waddleTime) {
            transform.eulerAngles = waddleLeft? waddleLeftRot : waddleRightRot;
            waddleLeft = !waddleLeft;
            timer = 0;
        }

        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }
}
