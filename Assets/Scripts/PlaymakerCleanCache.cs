
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [ActionCategory(ActionCategory.Device)]
    [Tooltip("清除快取")]
    public class PlaymakerCleanCache : FsmStateAction
    {



        public override void OnEnter()
        {
		UnityEngine.Caching.ClearCache();
		Finish();
        }

	

    }
}