using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : LogicObject
{
    // 生命值
    public int hp = 100;
    // 最大生命
    public int maxHp = 100;

    // 可移动范围
    public float maxX = 2.2f;
    public float minX = -2.2f;
    public float maxY = 2.2f;
    public float minY = -2.2f;

    // 移动速度
    public float speed = 0.03F;

    // 按键状态
    private int keyStyate = 0;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        checkKeyState();
       
	}

    void FixedUpdate()
    {
        checkMove();
    }

    // 监测飞机移动
    private void checkMove()
    {
        int sigleY = 0;
        int sigleX = 0;
        Vector3 pos;

        // w
        if ((keyStyate & 0x00001000) != 0)
        {
            pos = transform.localPosition;
            sigleY = 1;
            pos.y += sigleY * speed * Time.deltaTime;
            transform.localPosition = pos;
        }

        if ((keyStyate & 0x00000100) != 0)
        {
            pos = transform.localPosition;
            sigleY = -1;
            pos.y += sigleY * speed * Time.deltaTime;
            transform.localPosition = pos;
        }

        if ((keyStyate & 0x00000010) != 0)
        {
            pos = transform.localPosition;
            sigleX = -1;
            pos.x += sigleX * speed * Time.deltaTime;
            transform.localPosition = pos;
        }

        if ((keyStyate & 0x00000001) != 0)
        {
            pos = transform.localPosition;
            sigleX = 1;
            pos.x += sigleX * speed * Time.deltaTime;
            transform.localPosition = pos;
        }

        pos = transform.localPosition;
        if (pos.x > maxX)
        {
            pos.x = maxX;
        }
        if (pos.x < minX)
        {
            pos.x = minX;
        }
        if (pos.y > maxY)
        {
            pos.y = maxY;
        }
        if (pos.y < minY)
        {
            pos.y = minY;
        }

        transform.localPosition = pos;
    }


    // 监测X轴向的移动
    private void checkKeyState()
    {
        if (Input.GetKeyDown(KeyCode.W )|| Input.GetKeyDown(KeyCode.UpArrow))
        {
            keyStyate = ( keyStyate | 0x00001000 );
        }
        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.UpArrow))
        {
            keyStyate = (keyStyate & 0x00000111);
        }

        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            keyStyate = (keyStyate | 0x00000100);
        }
        if (Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.DownArrow))
        {
            keyStyate = (keyStyate & 0x00001011);
        }

        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            keyStyate = (keyStyate | 0x00000010);
        }
        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow))
        {
            keyStyate = (keyStyate & 0x00001101);
        }

        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            keyStyate = (keyStyate | 0x00000001);
        }
        if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            keyStyate = (keyStyate & 0x00001110);
        }

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        hp -= 10;

        if (hp > 0)
        {
            string url = "Prefab/Effect/Hit";
            GameObject hitPrefab = Resources.Load<GameObject>(url);

            GameObject hit = Instantiate(hitPrefab);

            HitEffect hitEffect = hit.GetComponent<HitEffect>();

            if (hitEffect)
                hitEffect.setParent( transform );

        }
        else
        {
              
        }
    }
}
