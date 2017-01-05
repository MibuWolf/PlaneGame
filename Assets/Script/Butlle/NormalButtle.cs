using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalButtle : ButlleBase
{
    // 运动方向
    public float dirX = 0.0f;

    // 运动方向
    public float dirY = 0.0f;

    // 运动速度
    public float speed;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        move();
        checkPostion();
    }


    // 移动子弹
    private void move()
    {
        Vector3 pos = transform.localPosition;
        pos.x += speed * dirX;
        pos.y += speed * dirY;

        transform.localPosition = pos;
    }


    // 监测位置区域
    private void checkPostion()
    {
        Vector3 pos = transform.localPosition;

        if (pos.x < -3 || pos.x > 3 || pos.y > 10 || pos.y < -5)
        {
            Destroy(gameObject);
        }
    }
}
