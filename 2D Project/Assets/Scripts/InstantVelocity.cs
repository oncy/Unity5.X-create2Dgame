using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantVelocity : MonoBehaviour {
	//速度变量
	public Vector2 velocity = Vector2.zero;
	//刚体变量
	private Rigidbody2D body2d;
	void Awake(){
		//获取刚体实例引用
		body2d = GetComponent<Rigidbody2D>();
	}
	void FixedUpdate(){
	//为刚体添加速度值
		body2d.velocity =velocity;
	}

}
   