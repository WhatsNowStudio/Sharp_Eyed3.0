using UnityEngine;
using System.Collections;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("AssetBundle")]
	[Tooltip("從ABs找到並實例化物件")]

public class PlayMakerLoadAssetsFromAbs : FsmStateAction
   {
	  [RequiredField]
	  [Tooltip("必填條件-Abs")]
	  [ObjectType(typeof(AssetBundle))]
	  public FsmObject Abs;

	  [Tooltip("必填條件-物件名稱")]
	  public FsmString GetByName;


	  [ActionSection("Results")]
	  [UIHint(UIHint.Variable)]
	  public FsmGameObject Getgameobject;
	  

	  [ActionSection("Events")] 
   	  [Tooltip("讀取成功發出Done")]
	  public FsmEvent isDone;
	  [Tooltip("讀取成功發出Error")]
	  public FsmEvent isError;

	  
      public override void Reset()
		{
			Getgameobject = null;
			Abs = null;
		}
	  public override void OnEnter()
	    {
			Getgameobject.Value = GameObject.Instantiate(((AssetBundle)Abs.Value).LoadAsset(GetByName.Value) as GameObject)as GameObject;
	    }

	  public override void OnUpdate()
	    {
		   if (Getgameobject.Value != null){
		   Fsm.Event(isDone);
		   }
			 if (Getgameobject.Value == null){
		   Fsm.Event(isError);
		   }
	    }
   }
	 

}
