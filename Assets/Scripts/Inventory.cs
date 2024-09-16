using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance { get; private set; }

    public bool raft = false;
    public bool lantern = false;
    public bool sailcloth = false;
    public bool compass = false;

    public float glimmers = 0;

    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    private void Update()
    {
        if (glimmers >= 4)
        {
            raft = true;
        }
    }
}
