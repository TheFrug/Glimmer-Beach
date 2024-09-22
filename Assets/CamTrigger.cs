using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamTrigger : MonoBehaviour
{
    [SerializeField] private Transform targetCamPosition;
    public Vector3 playerChange;

    CamController camControl;

    void Start()
    {
        camControl = Camera.main.GetComponent<CamController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            camControl.moveCamera(targetCamPosition);

            other.transform.position += playerChange;
        }
    }
}
