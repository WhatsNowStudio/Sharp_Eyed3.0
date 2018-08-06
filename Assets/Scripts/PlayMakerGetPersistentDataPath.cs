using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory(ActionCategory.Device)]
	[Tooltip("取得裝置預設資料路徑")]
	public class PlayMakerGetPersistentDataPath : FsmStateAction
	{
		
		[RequiredField]
		[UIHint(UIHint.Variable)]
		public FsmString storePath;
		

	
		public override void OnEnter()
		{
		storePath.Value = (Application.persistentDataPath);
		//Application.streamingAssetsPath
		}
		

	}
}