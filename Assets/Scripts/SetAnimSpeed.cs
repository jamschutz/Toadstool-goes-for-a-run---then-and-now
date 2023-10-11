using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetAnimSpeed : MonoBehaviour
{
    [Range(0,1)]
    public float speed;

    private void Start()
    {
        GetComponent<Animator>().speed = speed;
    }
}
