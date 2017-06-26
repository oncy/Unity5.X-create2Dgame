using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputState : MonoBehaviour {

	//标记游戏设备是否被点击
	public bool actionButtion;
	//X轴方向的速度变量
	public float absVelX = 0f;
	//Y轴方向的速度变量
	public float absVelY = 0f;
	//标记游戏对象是否站在地上
	public bool standing;
	//游戏对象站立边界阈值
	public float standingThreshold = 1f;
	//游戏对象变量
	private Rigidbody2D body2d;


	void Awake () {
		//获取游戏对象实例引用
		body2d = GetComponent<Rigidbody2D>();
		
	}
	

	void Update () {
		//检测屏幕任何输入信息
		actionButtion = Input.anyKeyDown;
	}

	void FixedUpdate(){
	    //获取刚体Y轴速度的绝对值
		absVelY = System.Math.Abs(body2d.velocity.y);
		//Y轴速度小于边界值说明刚体不在地面上
		standing = absVelY <= standingThreshold;
	}
}
