using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
	//游戏对象存储器
	public GameObject[] prefabs;
	//设置制造对象时间间隔
	public float delay = 2.0f;
	//计时器开关
	public bool active = true;
	//设置随机性取值范围
	public Vector2 delayRange = new Vector2(1,2);

	void Start () {
		//调用获取随机时间
		ResetDelay();
		//启动计时器
		StartCoroutine(EnemyGenerator());
	}
	//定时间间隔调用方法
	IEnumerator EnemyGenerator()
	{
		//延时方法
		yield return new WaitForSeconds (delay);
        //判断计时器是否开启
		if(active){
			var newTransform = transform;

			//随机克隆新对象
			//Instantiate(prefabs[Random.Range(0,prefabs.Length)],newTransform.position,Quaternion.identity);
			//替换为：
			gameObjectUtil.Instantiate(prefabs[Random.Range(0,prefabs.Length)],newTransform.position);

			//调用获取随机时间
			ResetDelay();
		}
			//启动计时器
			StartCoroutine(EnemyGenerator());
		
	}

	// Update is called once per frame
	void Update () {
		
	}
	void ResetDelay(){
	//获取间隔时间的方法
		delay = Random.Range(delayRange.x,delayRange.y);
	}

}
