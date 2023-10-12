using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventOnAwake : MonoBehaviour
{
    public UnityEvent events;


    public void Start()
    {
        events.Invoke();
    }
}
