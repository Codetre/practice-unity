using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // 1. 카메라는 플레이어 수직 위치를 따라다닌다.
    GameObject player;

    void Start()
    {
        this.player = GameObject.Find("cat");
    }

    void Update()
    {
        Vector3 playerPos = this.player.transform.position;
        transform.position = new Vector3(
            transform.position.x, playerPos.y, transform.position.z);
    }
}
