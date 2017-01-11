using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButlleEmitter : MonoBehaviour {

    // 是否属于主角
    public bool bPlayer = true;

    // 子弹产生间隔
    public float dtTime = 0.5f;

    // 产生新子弹的剩余时间
    private float time = 0.0f;

    // 产生子弹类型(普通/散弹/。。。。)
    public enum ButlleType{ normal,dazhao,dazhao2 }
    public ButlleType butlleType = ButlleType.normal;

    // 子弹材质类型
    public int type = 1;

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {

        time -= Time.deltaTime;

        if (time <= 0)
        {
            time = dtTime;

            switch (butlleType)
            {
                case ButlleType.normal:
                    {
                        createNormalButlle();
                    }
                    break;
                case ButlleType.dazhao:
                    {
                        createDazhaoButlle();
                    }
                    break;
                case ButlleType.dazhao2:
                    {
                        createDazhaoButlle2();
                    }
                    break;
            }
            
        }

    }


    // 释放大招
    public void setDazhao()
    {
        type = 4;
        butlleType = ButlleType.dazhao;
        dtTime = 0.3f;
        time = 0.0f;
        Invoke("resetNormal", 3);
    }


    // 释放大招2
    public void setDazhao2()
    {
        type = 4;
        butlleType = ButlleType.dazhao2;
        dtTime = 0.3f;
        time = 0.0f;
        Invoke("resetNormal", 3);
    }


    void resetNormal()
    {
        type = 1;
        butlleType = ButlleType.normal;
        time = 0.0f;
        dtTime = 0.1f;
    }

    // 生成一个新的普通子弹
   virtual protected void createNormalButlle()
    {

        Vector3 pos = transform.position;

        Vector3 cameraPos = Camera.main.transform.position;

        if ((pos.x - cameraPos.x) < -3 || (pos.x - cameraPos.x) > 3 || (pos.y - cameraPos.y) > 10 || (pos.y - cameraPos.y) < -5)
        {
            return;
        }

        GameObject butlle = Instantiate<GameObject>(Resources.Load("Prefab/Bullet/NormalBullet"+ type.ToString()) as GameObject);
        butlle.GetComponent<NormalButtle>().bPlayer = bPlayer;
        butlle.transform.parent = transform;
        //butlle.transform.localPosition = transform.localPosition;
        butlle.transform.position = transform.position;
    }


    // 生成一个大招类型子弹
    virtual protected void createDazhaoButlle()
    {
        Vector3 pos = transform.position;

        Vector3 cameraPos = Camera.main.transform.position;

        if ((pos.x - cameraPos.x) < -3 || (pos.x - cameraPos.x) > 3 || (pos.y - cameraPos.y) > 10 || (pos.y - cameraPos.y) < -5)
        {
            return;
        }

        for (int i = 0; i < 36; ++i)
        {
            GameObject butlle = Instantiate<GameObject>(Resources.Load("Prefab/Bullet/NormalBullet" + type.ToString()) as GameObject);
            butlle.GetComponent<NormalButtle>().bPlayer = bPlayer;
            butlle.GetComponent<NormalButtle>().dirX = Mathf.Cos(i * Mathf.PI / 18.0f);
            butlle.GetComponent<NormalButtle>().dirY = Mathf.Sin(i * Mathf.PI / 18.0f);
            butlle.transform.parent = transform;
            //butlle.transform.localPosition = transform.localPosition;
            butlle.transform.position = transform.position;
        }

    }

    // 生成一个大招类型2子弹
    virtual protected void createDazhaoButlle2()
    {
        Vector3 pos = transform.position;

        Vector3 cameraPos = Camera.main.transform.position;

        if ((pos.x - cameraPos.x) < -3 || (pos.x - cameraPos.x) > 3 || (pos.y - cameraPos.y) > 10 || (pos.y - cameraPos.y) < -5)
        {
            return;
        }

        for (int i = 0; i < 40; ++i)
        {
            GameObject butlle = Instantiate<GameObject>(Resources.Load("Prefab/Bullet/NormalBullet" + type.ToString()) as GameObject);
            butlle.GetComponent<NormalButtle>().bPlayer = bPlayer;
            butlle.transform.parent = transform;
            //butlle.transform.localPosition = transform.localPosition;
            pos = transform.position;
            pos.x = pos.x - 5.0f + 0.25f * i;
            butlle.transform.position = pos;
        }

    }
}
