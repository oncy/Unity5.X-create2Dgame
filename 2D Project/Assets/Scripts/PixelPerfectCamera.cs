using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PixelPerfectCamera : MonoBehaviour {

	// Use this for initialization
	//单元格像素大小
	public static float pixelTOUnity=100.0f;
	//比例值
	public static float scale =1.0f;
	//默认分辨率
	public Vector2 nativeResolution = new Vector2 (1136,640);
	//初始化摄像机
	void Awake(){
		//创建摄像机变量并获取实例
		var camera =GetComponent<Camera>();
		//判断是否为正交摄像机
		if(camera.orthographic){
			//计算比例
			scale = Screen.height/nativeResolution.y;
			//单元像素比例值
			pixelTOUnity *=scale;
			//给正交摄像机赋值
			camera.orthographicSize =(Screen.height/2)/pixelTOUnity;
		}
	}
}
