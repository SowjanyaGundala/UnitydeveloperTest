﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroManager : MonoBehaviour
{
    private static GyroManager instance;
    public static GyroManager Instance
    {
        get
        {
            if(instance==null)
            {
                instance = FindObjectOfType<GyroManager>();
                if(instance==null)
                {
                    instance = new GameObject("Spawned GyroManager", typeof(GameObject)).GetComponent<GyroManager>();
                }
            }
            return instance;
        }

        set
        {
            instance = value;
        }
    }

    private Gyroscope gyro;
    private Quaternion rotation;
    private bool gyroActive;

    public void EnableGyro()
    {
        if (gyroActive)
            return;
        if(SystemInfo.supportsGyroscope)
        {
            gyro = Input.gyro;
            gyro.enabled = true;
            gyroActive = gyro.enabled;
        }
        else
        {
            Debug.Log("Gyro not active");
        }
        
    }

    private void Update()
    {
        if(gyroActive)
        {
            rotation = gyro.attitude;
        }
    }

    public Quaternion GetGyroRotation()
    {
        return rotation;
    }
}