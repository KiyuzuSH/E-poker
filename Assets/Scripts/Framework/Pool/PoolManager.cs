using UnityEngine;
using System.Collections.Generic;

namespace ObjPool
{
	/// <summary> 池子的总管理器 </summary>
	public class PoolManager
	{
		private static PoolManager instance;
		public static PoolManager Instance
		{
			get
			{
				if(instance == null)
				{
					instance = new PoolManager();
				}
				return instance;
			}
		}

		/// <summary> 池子的配置文件目录 </summary>
		public const string PoolConfigPath = "Assets/Scripts/Framework/Pool/pool.asset";

		/// <summary> 字典。Key->池子名字，Value->池子Object </summary>
		private Dictionary<string, ObjectPool> poolDict = new Dictionary<string, ObjectPool>();

		public PoolManager()
		{
			ObjectPoolList objectPoolList = Resources.Load<ObjectPoolList>("pool");

			foreach(var pool in objectPoolList.PoolList)
			{
				this.poolDict.Add(pool.Name, pool);
			}
		}

		/// <summary> 根据名字取物体 </summary>
		public GameObject GetObject(string poolName)
		{
			if(!poolDict.ContainsKey(poolName))
			{
				Debug.LogError("没有名为 " + poolName + " 的池子！");
				return null;
			}

			ObjectPool pool = poolDict[poolName];
			return pool.GetObject();
		}

		/// <summary> 隐藏指定物体 </summary>
		public void HideObjet(GameObject go)
		{
			foreach(ObjectPool p in poolDict.Values)
			{
				if(p.Contains(go))
				{
					p.HideObject(go);
					return;
				}
			}
		}

		/// <summary> 指定一个池子隐藏该池子内的所有物体 </summary>
		public void HideAllObject(string poolName)
		{
			if(!poolDict.ContainsKey(poolName))
			{
				Debug.LogError("没有这个 " + poolName + " 池子！");
				return;
			}
			ObjectPool pool = poolDict[poolName];
			pool.HideAllObject();
		}

		/// <summary> 还原对象池 </summary>
		public void InitAllPool()
		{
			foreach(var pool in poolDict.Values)
			{
				pool.InitPool();
			}
		}
	}
}
