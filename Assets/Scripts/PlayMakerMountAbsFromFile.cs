using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("AssetBundle")]
	[Tooltip("讀取Abs從本地檔案")]

public class PlayMakerMountAbsFromFile : FsmStateAction
{
	[RequiredField]
	[Tooltip("必填條件為檔案路徑")]
	public FsmString FilePath;




	[ActionSection("Results")]
	[UIHint(UIHint.Variable)]
	[ObjectType(typeof(AssetBundle))]
	[Tooltip("從檔案路徑掛載Assetbundle")]
	public FsmObject storeBundle;

	[UIHint(UIHint.Variable)] 
	[Tooltip("How far the download progressed (0-1).")]
	public FsmFloat progress;

	



	[ActionSection("Events")] 
	[Tooltip("讀取完成後發出事件(progress = 1).")]
	public FsmEvent isDone;



	AssetBundleCreateRequest assetRequest;


	public override void Reset()
	{
		FilePath = null;
		storeBundle = null;
		progress = null;
	}
	
	public override void OnEnter()
	{
		assetRequest = AssetBundle.LoadFromFileAsync(FilePath.Value);

	}
	

	public override void OnUpdate()
	{
		progress.Value = assetRequest.progress;

		if(assetRequest.isDone)
		{	
			storeBundle.Value = assetRequest.assetBundle;
			Fsm.Event(isDone);
		}

	}
 } 
}
