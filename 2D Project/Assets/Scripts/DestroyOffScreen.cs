using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOffScreen : MonoBehaviour {

	//移除屏幕外的距离，用于判断何时销毁对象
	public float offset = 16.0f;
	//判断是否在屏幕外
	private bool offscreen;
	//当前屏幕宽度
	private float offscreenX = 0;
	//将要销毁的克隆体游戏对象
	private Rigidbody2D body2D;

	// Use this for initialization
	void Awake () {
		body2D = GetComponent<Rigidbody2D> ();
	}

	void Start() {
	//移除屏幕的坐标位置值
		offscreenX = (Screen.width / PixelPerfectCamera.pixelTOUnity) / 2 + offset;
	}
	
	// Update is called once per frame
	void Update () {
		//x轴实时坐标信息
		var posX = transform.position.x;
		//存储运动方向
		var dirX = body2D.velocity.x;
		//判断posX的绝对值是否大于出屏值；
		if(Mathf.Abs(posX) > offscreenX){
			//大于判断出屏
			offscreen = true;
		}
		else
			//小于判断则没出屏
			offscreen = false;
		if (Mathf.Abs (posX) > offscreenX) {
			//判断posX的绝对值是否大于出屏值
			if(dirX < 0 && posX < -offscreenX)
				//标记已出屏
				offscreen =true;
			//判断posX的绝对值是否大于出屏值
			else if (dirX >0 && posX > offscreenX)
				//标记已经出屏
				offscreen = true ;
			else
				//标记未出屏
				offscreen = false;
		}
		if (offscreen) {
			OnOutBounds ();
		}
	}
	public void OnOutBounds(){
		offscreen = false;
		/*gameObjectUtil.*/Destroy (gameObject);
	}
}
