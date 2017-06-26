using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecycleGameObject : MonoBehaviour {

	private List<IRecyle> recycleComponents;

	void Awake(){
		var components = GetComponents<MonoBehaviour> ();
		recycleComponents = new List<IRecyle> ();
		foreach(var component in components){
			if (component is IRecyle) {
				recycleComponents.Add (component as IRecyle);
			}
		}
	}
	//重新启动对象
	public void Restart(){
		//激活游戏对象
		gameObject.SetActive(true);
		foreach (var component in recycleComponents) {
			component.Restart ();
		}
	}

	//关闭对象
	public void Shutdown(){
		//关闭游戏对象
		gameObject.SetActive (false);
		foreach (var component in recycleComponents) {
			component.Shutdown();
		}
	}


	public interface IRecyle{
		void Restart ();
		void Shutdown ();

	}

}
 