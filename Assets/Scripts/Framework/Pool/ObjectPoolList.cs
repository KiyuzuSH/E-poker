using UnityEngine;
using System.Collections.Generic;

namespace ObjPool
{
	/// <summary> 池子列表 </summary>
	public class ObjectPoolList : ScriptableObject
	{
		public List<ObjectPool> PoolList;
	}
}
