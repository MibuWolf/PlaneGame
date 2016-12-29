using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBase : LogicObject
{
    // 生命值
    public int hp;
    // 最大生命
    public int maxHp;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    protected void checkHP()
    {
        if (hp <= 0)
        {
            Dispose();
        }
    }

    override public void Dispose()
    {
        base.Dispose();
        hp = maxHp = 0;
    }

}
