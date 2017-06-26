using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour {
	//创建一个原型变量
	public RecycleGameObject prefab;
	private List<RecycleGameObject>
		poolInstance = new List<RecycleGameObject> ();
	//创建对象实例方法
	private RecycleGameObject CreateInstance(Vector3 pos){
		//原型体克隆一个对象
		var clone = GameObject.Instantiate(prefab);
		//给克隆体定位
		clone.transform.position = pos;
		//克隆体的transform父类与对象池同步
		clone.transform.parent = transform;
		//把克隆体放入对象池存储器
		poolInstance.Add(clone);
		//返回克隆体对象
		return clone ;
	}


	//获取游戏对象方法
	public RecycleGameObject NextObject(Vector3 pos){
		//创建一个获取克隆体变量
		RecycleGameObject instance = null ;
		//调用方法获取克隆体实例
		instance = CreateInstance(pos);
		//激活克隆对象
		instance.Restart();
		foreach (var go in poolInstance) {
			if (go.gameObject.activeSelf != true) {
				instance = go;
				instance.transform.position = pos;
			}

		}
		//返回克隆体对象
		return instance;
	}

}
