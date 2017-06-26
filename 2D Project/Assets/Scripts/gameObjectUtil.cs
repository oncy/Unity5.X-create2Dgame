using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameObjectUtil {
	
	//实例变量
	//static GameObject instance = null;
	//创建字典表管理克隆体与对象池
	private static Dictionary<RecycleGameObject,ObjectPool > pools = new Dictionary<RecycleGameObject, ObjectPool>();

	//初始化静态类方法
	public static GameObject Instantiate(GameObject prefab ,Vector3 pos){
		//创建一个空对象来持有游戏对象克隆体
		GameObject instance = null;
		//从克隆器中获取可复用对象
		var recycledScript = prefab.GetComponent<RecycleGameObject>();
		//如果获取的对象不是可复用对象，升级它并放入对象池
		if (recycledScript != null) {
			//放入对象池
			var pool = GetObjectPool (recycledScript);
			//激活克隆对象
			instance = pool.NextObject (pos).gameObject;
		} 
		else {
		    //新创建一个游戏克隆对象
			instance = GameObject.Instantiate(prefab);
			//设置位置
			instance.transform.position = pos;
		}
		//初始化游戏对象
		//instance = GameObject.Instantiate(prefab); 
		//初始化对象位置
		//instance.transform.position = pos ;
		//返回游戏实例
		return instance;
	}


/*	public static void Destroy(GameObject gameObject){
		//获取具有可复用功能的待销毁对象
		var recyleGameObject = gameObject.GetComponent<RecycleGameObject>();
		//判断对象是否具有可复用功能
		if (RecycleGameObject != null) {
			//具有可复用性关闭活性
			RecycleGameObject.Shutdown ();
		} 
		else {
			//不具备可复用性销毁
			GameObject.Destroy (gameObject);
		}
	}*/


	//查询对象池中的克隆体对象
	private static ObjectPool GetObjectPool(RecycleGameObject reference){
		//对象池变量
		ObjectPool pool = null;
		//查询对象池是否存在我们需要的游戏对象克隆体
		if (pools.ContainsKey (reference)) {
			//如果有，从对象池中获取引用
			pool = pools [reference];
		}
		//如果没有，我们重新创建新对象并存储在对象中
		else {
		//创建对象池容量
			var poolContainer = new GameObject(reference.gameObject.name /*+ ObjectPool*/);
			//为对象池容量添加对象池组件
			pool = poolContainer.AddComponent<ObjectPool>();
			//添加克隆器
			pool.prefab = reference;
			//把克隆器与对象池添加进对象池存储器
			pools.Add(reference,pool);
		}
		//返回对象池
		return pool;
	}

}


