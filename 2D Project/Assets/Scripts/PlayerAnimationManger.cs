using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationManger : MonoBehaviour {

	// 持有游戏主角动作管理器
	private Animator animator;
	//持有游戏主角状态监控器
	private InputState inputState;
	void Awake () {
		//获取游戏对象动作管理器实例引用
		animator = GetComponent<Animator>();
		//获取游戏主角状态监控器实例引用
		inputState = GetComponent<InputState>();
		
	}
	
	// Update is called once per frame
	void Update () {
		//根据standing值设置动画控制器中running的值
		animator.SetBool("Running",inputState.standing);
	}
}
