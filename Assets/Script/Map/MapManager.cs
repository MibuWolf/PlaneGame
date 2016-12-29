using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour {

    // 地图资源
    public int mapLevel = 1;
    public int mapCount = 1;
    // 单张地图高
    public float mapHeight;
    // 整张地图最大值
    public Vector3 maxRange;
    // 整张地图最小值
    public Vector3 minRange;
    // 移动速度
    public float speed;
    // 当前整张地图起始点
    private Vector3 curPositon;
    // 所有地图块信息
    private GameObject[] maps;
    // Use this for initialization
    void Start () {

        string url = "Prefab/Map/MapBlock" + mapLevel.ToString();
        GameObject mapRes = Resources.Load<GameObject>(url);

        if (mapCount > 0)
        {
            maps = new GameObject[mapCount];

            for (int i = 0; i < mapCount; ++i)
            {
                maps[i] = Instantiate(mapRes);

                Vector3 curPos = maps[i].transform.localPosition;
                curPos.y += mapHeight * i;
                maps[i].transform.localPosition = curPos;
            }
        }

        curPositon.x = curPositon.y = curPositon.z = 0;

        UpdateMaps();
    }
	
	// Update is called once per frame
	void Update () {

        UpdateMaps();

    }

    private void UpdateMaps()
    {
        int index = 0;

        foreach (GameObject map in maps)
        {
            if (map)
            {
               // Vector3 curPos = map.transform.localPosition;
               // curPos.y -= speed * Time.deltaTime;

               // map.transform.localPosition = curPos;

                map.transform.localPosition = Vector3.MoveTowards(map.transform.localPosition, new Vector3(0, -200f, 0), Time.deltaTime * speed);
                index++;
            }
        }
    }
}
