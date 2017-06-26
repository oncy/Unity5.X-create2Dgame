using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiledBackground : MonoBehaviour {
	
	//单元格像素值
	public static float pixelToUnit =100.0f;
	//瓦砾材质的尺寸
	public int textureSize =128;
	// Use this for initialization
	void Start () {
		//计算当前屏幕分辨率需要几块瓦砾来填充
		var newWidth =Mathf.Ceil(Screen.width/(textureSize * PixelPerfectCamera.scale));
		//Quad的宽度比例值
		transform.localScale =new Vector3((newWidth*textureSize)/pixelToUnit,1,1);
		//为瓦砾材质块数赋值
		GetComponent<Renderer>().material.mainTextureScale = new Vector3(newWidth,1,1);
	}

}
