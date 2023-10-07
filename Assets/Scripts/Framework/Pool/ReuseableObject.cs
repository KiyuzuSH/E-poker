using UnityEngine;

namespace ObjPool
{
	/// <summary> 可复用Obj </summary>
	public abstract class ReuseableObject : MonoBehaviour
	{
		/// <summary> 取出之前的重置操作 </summary>
		public abstract void BeforeGetObject();


		/// <summary> 放入之前的还原操作 </summary>
		public abstract void BeforeHideObject();
	}
}
