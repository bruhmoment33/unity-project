using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAttach : MonoBehaviour
{
    public Transform player, mainCamera;

    public bool attach = true;

    void Update()
    {
        if (!attach) return;
        mainCamera.position = player.position + new Vector3(0f, 2f, -7.1f);
    }
}
