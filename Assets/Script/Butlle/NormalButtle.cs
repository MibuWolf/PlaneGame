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
        Vector3 pos = transform.position;
        pos.x += speed * dirX;
        pos.y += speed * dirY;
 
        Quaternion qR = transform.parent.rotation;

        transform.position = pos;
        transform.rotation = qR;
    }


    // 监测位置区域
    private void checkPostion()
    {
        Vector3 pos = transform.position;

        Vector3 cameraPos = Camera.main.transform.position;

        if (( pos.x - cameraPos.x) < -3 || (pos.x - cameraPos.x) > 3 || (pos.y - cameraPos.y) > 10 || (pos.y - cameraPos.y) < -5)
        {
            Destroy(gameObject);
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        // 玩家子弹击中怪物
        if (other.gameObject.tag == "Monster")
        {
            if (bPlayer)
            {
                NormalMonster monster = other.gameObject.GetComponent<NormalMonster>();
                monster.OnHit(damage);
                Destroy(gameObject);
            }
        }

        // 玩家被怪物击中
        if (other.gameObject.tag == "Player")
        {
            // 玩家子弹击中怪物
            if (!bPlayer)
            {
                Player player = other.gameObject.GetComponent<Player>();
                player.OnHit(damage);
                Destroy(gameObject);
            }
        }
    }
}
