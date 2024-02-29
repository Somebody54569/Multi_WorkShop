using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class HostSingleton : MonoBehaviour
{
    private static HostSingleton instance;
    public HostGameManger GameManager { get; private set; }

    public static HostSingleton Instance
    {
        get
        {
            if (instance != null) { return instance; }
            instance = FindFirstObjectByType<HostSingleton>();

            if (instance == null)
            {
                Debug.LogError("No HostSingleton in the scene!");
                return null;
            }

            return instance;
        }
    }
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    public void CreateHost()
    {
        GameManager = new HostGameManger();
    }

    private void OnDestroy()
    {
        GameManager?.Dispose();
    }
}
