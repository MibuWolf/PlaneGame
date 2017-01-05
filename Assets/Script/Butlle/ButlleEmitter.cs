﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButlleEmitter : MonoBehaviour {

    // 是否属于主角
    public bool bPlayer = true;

    // 子弹产生间隔
    public float dtTime = 0.5f;

    // 产生新子弹的剩余时间
    private float time = 0.0f;

    // 产生子弹类型
    public enum ButlleType{ normal }
    public ButlleType butlleType = ButlleType.normal;


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
            }
            
        }

    }



    // 生成一个新的普通子弹
    private void createNormalButlle()
    {
        GameObject butlle = Instantiate<GameObject>(Resources.Load("Prefab/Bullet/NormalBullet") as GameObject);

        butlle.transform.parent = transform;
        butlle.transform.localPosition = transform.localPosition;

    }
}