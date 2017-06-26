using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour {

	//跳跃速度
	public float jumpSpeed = 20f;
	//游戏主角对象
	private Rigidbody2D body2D;
	//状态检测组件
	private InputState inputState;
	//向前的速度
	public float forwardSpeed = 6;
	//初始化方法
	void Awake () {
		body2D = GetComponent<Rigidbody2D> ();
		inputState = GetComponent<InputState> ();
	}
	
	// Update is called once per frame
	void Update () {
		//判断游戏主角是否站立在地面上
		if(inputState.standing){
			//判断玩家是否点击屏幕
			if(inputState.actionButtion){
				//给游戏主角一个向上的力,并向前给个速度
				body2D.velocity = new Vector2(forwardSpeed,jumpSpeed);
			}
		}
			
	}
}
