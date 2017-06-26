using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatedTexture : MonoBehaviour {
	//运动速度
	public Vector2 speed = Vector2.zero;
	//偏移量步长
	private Vector2 offset = Vector2.zero;
	//运动材质
	private Material material;
	//初始化函数
	void Start () {
		//获取材质实例
		material = GetComponent<Renderer>().material;
		//获取材质偏移量属性
		offset = material.GetTextureOffset("_MainTex");
	}
	
	// Update is called once per frame
	void Update () {
		//迭代递增偏移量
		offset += speed *Time.deltaTime;
		//更新材质偏移量属性
		material.SetTextureOffset("_MainTex",offset);
	}
}
