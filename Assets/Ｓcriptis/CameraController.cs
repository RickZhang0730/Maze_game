using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("玩家物件")]
    public GameObject player;

    [Header("相對位移")]
    public Vector3 offset;//宣告成public可以即時修改數值
    // Start is called before the first frame update
    
    void Start()
    {
        offset = transform.position - player.transform.position;
        //相對位移
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
        //攝影機座標
    }
}
