using UnityEngine;
using UnityEditor;

namespace ObjPool
{
	/// <summary> 池子编辑器 </summary>
	public class PoolEditor : MonoBehaviour
	{
		/// <summary>
		/// 创建池子列表，需要 PoolConfig
		/// </summary>
		[MenuItem("Manager/Create PoolConfig")]
		static void CreatePoolList()
		{
			ObjectPoolList poolList = ScriptableObject.CreateInstance<ObjectPoolList>();
			string path = PoolManager.PoolConfigPath;
			AssetDatabase.CreateAsset(poolList, path);
			AssetDatabase.SaveAssets();
			EditorUtility.DisplayDialog("提示", "创建成功", "好的");
		}
	}
}
