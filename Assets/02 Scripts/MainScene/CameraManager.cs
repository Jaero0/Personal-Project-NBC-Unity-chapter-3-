using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Camera Camera;
    public GameObject player;

    Transform plTr;
    Transform camTr;

    void Awake()
    {
        plTr = player.transform;
        camTr = Camera.main.transform;
    }

    void Update()
    {
        CamFollowPlayer();
    }


    void CamFollowPlayer()
    {
        camTr.position = new Vector3(plTr.position.x, plTr.position.y, camTr.position.z);
    }
}
