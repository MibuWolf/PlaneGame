using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterCreater : MonoBehaviour {

    // 产生敌机的配置文件
    private MonsterInitData[] datas;

    // 当前飞机波次
    private int index = 0;

    private float curTime = 0.0f;
	// Use this for initialization
	void Start ()
    {
        datas = new MonsterInitData[] { new MonsterInitData(0.5f, 1, new Vector3( 1.2f, 3.0f, 0.0f ), new Vector3( 0.0f, -1.0f,0.0f ), 1.0f, 1.0f), new MonsterInitData(1.3f, 1, new Vector3( -0.5f, 3.3f, 0.0f), new Vector3( 0.1f,-0.9f,0.0f ), 1.5f, 1.0f),
            new MonsterInitData(2.0f, 1, new Vector3( -2.0f, 3.0f, 0.0f ), new Vector3( 0.3f, -1.0f, 0.0f ), 2.0f, 1.0f), new MonsterInitData( 3.8f, 1, new Vector3( 2.0f, 3.6f, 0.0f ), new Vector3( -0.2f, -0.9f, 0.0f ), 1.0f, 1.0f),
            new MonsterInitData(4.0f, 1, new Vector3(-0.2f,3.0f,0.0f), new Vector3(0.0f,-1.0f,0.0f), 1.0f, 1.0f), new MonsterInitData( 5.2f, 1, new Vector3( 1.7f,3.0f, 0.0f ), new Vector3( -0.2f, -0.9f, 0.0f ), 1.8f, 1.0f),
            new MonsterInitData( 5.3f, 2, new Vector3( -1.7f,3.0f, 0.0f ), new Vector3( 0.2f, -0.9f, 0.0f ), 1.6f, 0.8f), new MonsterInitData( 5.8f, 2, new Vector3( 0.0f,3.0f, 0.0f ), new Vector3( 0.2f, -0.9f, 0.0f ), 1.6f, 0.8f),
            new MonsterInitData( 7.2f, 2, new Vector3( 1.7f,3.0f, 0.0f ), new Vector3( -0.2f, -0.9f, 0.0f ), 1.6f, 0.8f),  new MonsterInitData( 8.0f, 2, new Vector3( -1.7f,3.0f, 0.0f ), new Vector3( 0.2f, -0.9f, 0.0f ), 1.6f, 0.8f),
            new MonsterInitData( 9.0f, 2, new Vector3( 0.0f,3.0f, 0.0f ), new Vector3( -0.0f, -0.9f, 0.0f ), 1.6f, 0.8f),  new MonsterInitData( 9.5f, 2, new Vector3( 1.7f,3.0f, 0.0f ), new Vector3( -0.2f, -0.9f, 0.0f ), 1.6f, 0.8f),
            new MonsterInitData( 9.8f, 3, new Vector3( 2.0f,3.0f, 0.0f ), new Vector3( -0.2f, -1.0f, 0.0f ), 1.5f, 0.6f),   new MonsterInitData( 10.5f, 3, new Vector3( -2.0f,3.0f, 0.0f ), new Vector3( 0.2f, -0.9f, 0.0f ), 1.5f, 0.8f),
            new MonsterInitData( 10.9f, 3, new Vector3( -2.0f,3.0f, 0.0f ), new Vector3( 0.0f, -1.0f, 0.0f ), 1.5f, 0.8f), new MonsterInitData( 11.5f, 3, new Vector3( -1.0f,3.0f, 0.0f ), new Vector3( 0.0f, -1.0f, 0.0f ), 1.5f, 0.8f),
            new MonsterInitData( 12.4f, 3, new Vector3( 0.0f,3.0f, 0.0f ), new Vector3( 0.0f, -1.0f, 0.0f ), 1.5f, 0.8f), new MonsterInitData( 13.2f, 3, new Vector3( 1.0f,3.0f, 0.0f ), new Vector3( 0.0f, -1.0f, 0.0f ), 1.5f, 0.8f),
            new MonsterInitData( 14.2f, 4, new Vector3( 2.2f,3.0f, 0.0f ), new Vector3( -0.3f, -1.0f, 0.0f ), 1.4f, 0.6f),  new MonsterInitData( 15.0f, 4, new Vector3( 1.2f,3.0f, 0.0f ), new Vector3( -0.2f, -1.0f, 0.0f ), 1.4f, 0.6f),
            new MonsterInitData( 15.9f, 4, new Vector3( 0.0f,3.0f, 0.0f ), new Vector3( 0.0f, -1.0f, 0.0f ), 1.4f, 0.8f),  new MonsterInitData( 16.6f, 4, new Vector3( -1.2f,3.0f, 0.0f ), new Vector3( 0.2f, -1.0f, 0.0f ), 1.4f, 0.8f),
            new MonsterInitData( 17.2f, 4, new Vector3( -1.8f,3.0f, 0.0f ), new Vector3( 0.2f, -1.0f, 0.0f ), 1.4f, 0.8f),   new MonsterInitData( 18.0f, 4, new Vector3( -2.0f,3.0f, 0.0f ), new Vector3( 0.3f, -1.0f, 0.0f ), 1.4f, 0.8f),
            new MonsterInitData( 19.2f, 5, new Vector3( 2.2f,3.0f, 0.0f ), new Vector3( -0.3f, -1.0f, 0.0f ), 1.3f, 0.8f),  new MonsterInitData( 20.0f, 5, new Vector3( 2.0f,3.0f, 0.0f ), new Vector3( -0.2f, -1.0f, 0.0f ), 1.3f, 0.8f),
            new MonsterInitData( 20.6f, 5, new Vector3( 1.2f,3.0f, 0.0f ), new Vector3( -0.1f, -1.0f, 0.0f ), 1.3f, 0.8f),  new MonsterInitData( 21.2f, 5, new Vector3( -1.2f,3.0f, 0.0f ), new Vector3( 0.4f, -1.0f, 0.0f ), 1.3f, 0.8f),
            new MonsterInitData( 22.0f, 5, new Vector3( -2.0f,3.0f, 0.0f ), new Vector3( 0.3f, -1.0f, 0.0f ), 1.3f, 0.8f), new MonsterInitData( 22.8f, 5, new Vector3( -2.2f,3.0f, 0.0f ), new Vector3( 0.3f, -1.0f, 0.0f ), 1.3f, 0.8f),
            new MonsterInitData( 23.5f, 6, new Vector3( 2.2f,3.2f, 0.0f ), new Vector3( -0.1f, -1.0f, 0.0f ), 1.2f, 0.8f),  new MonsterInitData( 24.2f, 6, new Vector3( 1.2f,3.1f, 0.0f ), new Vector3( -0.2f, -1.0f, 0.0f ), 1.2f, 0.8f),
            new MonsterInitData( 24.8f, 6, new Vector3( -1.2f,3.2f, 0.0f ), new Vector3( 0.4f, -1.0f, 0.0f ), 1.2f, 0.8f),   new MonsterInitData( 25.5f, 6, new Vector3( -2.0f,3.0f, 0.0f ), new Vector3( 0.02f, -1.0f, 0.0f ), 1.2f, 0.8f),
            new MonsterInitData( 26.1f, 6, new Vector3( 2.0f,3.0f, 0.0f ), new Vector3( 0.0f, -1.0f, 0.0f ), 1.2f, 0.8f),  new MonsterInitData( 26.9f, 6, new Vector3( 1.0f,3.0f, 0.0f ), new Vector3( 0.0f, -1.0f, 0.0f ), 1.2f, 0.8f),
            new MonsterInitData( 27.6f, 6, new Vector3( -1.0f,3.0f, 0.0f ), new Vector3( 0.0f, -1.0f, 0.0f ), 1.5f, 0.8f), new MonsterInitData( 28.3f, 6, new Vector3( -2.0f,3.0f, 0.0f ), new Vector3( 0.0f, -1.0f, 0.0f ), 1.3f, 0.8f),
            new MonsterInitData( 28.8f, 6, new Vector3( 0.0f,3.0f, 0.0f ), new Vector3( 0.0f, -1.0f, 0.0f ), 1.5f, 0.8f),  new MonsterInitData( 29.0f, 6, new Vector3( 1.8f,3.0f, 0.0f ), new Vector3( -0.5f, -1.0f, 0.0f ), 1.5f, 0.3f),
            new MonsterInitData( 29.2f, 5, new Vector3( 1.0f,3.0f, 0.0f ), new Vector3( -0.2f, -1.0f, 0.0f ), 1.5f, 0.3f), new MonsterInitData( 30.0f, 4, new Vector3( -1.8f,3.0f, 0.0f ), new Vector3( 0.4f, -1.0f, 0.0f ), 1.5f, 0.3f)
        };

    }
	
	// Update is called once per frame
	void Update () {
        curTime += Time.deltaTime;

        if (index >= datas.Length)
            return;

        MonsterInitData data = datas[index];

        if (data.initTime <= curTime)
        {
            string url = "Prefab/Monster/monster" + data.monsterType.ToString();

            GameObject monster = Instantiate( Resources.Load(url) ) as GameObject;

            NormalMonster monsterScript = monster.GetComponent<NormalMonster>();
            monsterScript.velocity.x = data.dir.x;
            monsterScript.velocity.y = data.dir.y;
            monsterScript.speed = data.speed;
            
            if(data.monsterType < 3)
                monsterScript.hp = 10 * data.monsterType;
            else
                monsterScript.hp = 30;
            monster.transform.position = data.initPos;

            ButlleEmitter emitter = monster.GetComponent<ButlleEmitter>();
            emitter.bPlayer = false;
            emitter.dtTime = data.deltTime;

            index++;
        }

    }
}



public class MonsterInitData
{
    // 出现时间
    public float initTime;
    // 怪物类型(monster后缀)
    public int monsterType;
    // 初始化位置
    public Vector3 initPos;
    // 初始化速度
    public Vector3 dir;
    // 初始化飞行速度
    public float speed;
    // 初始化子弹间隔
    public float deltTime;

    public MonsterInitData( float _initTime, int _monsterType, Vector3 _initPos, Vector3 _dir, float _speed, float _deltTime )
    {
        initTime = _initTime;
        monsterType = _monsterType;
        initPos = _initPos;
        dir = _dir;
        speed = _speed;
        deltTime = _deltTime;
    }
}