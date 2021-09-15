using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{

    [SerializeField] private float maxX, minX;
    private Transform player;
    private Vector3 tempPos;

    private void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    private void LateUpdate()
    {
        if(player==null)    return;

        tempPos = transform.position;
        tempPos.x = player.position.x;
        tempPos.x = Mathf.Clamp(tempPos.x, minX, maxX);
        transform.position = tempPos;
    }
}
