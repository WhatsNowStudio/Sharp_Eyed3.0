using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [ActionCategory(ActionCategory.Device)]
    [Tooltip("取得運行平台")]
    public class PlayMakerGetRuntimePlatform : FsmStateAction
    {

        [RequiredField]
        [UIHint(UIHint.Variable)]
        public FsmString storePlatform;



        public override void OnEnter()
        {
            if (Application.platform == RuntimePlatform.Android)
                storePlatform.Value = ("Android");
            if (Application.platform == RuntimePlatform.WindowsEditor)
                storePlatform.Value = ("Win");
            if (Application.platform == RuntimePlatform.IPhonePlayer)
                storePlatform.Value = ("ios");

        Finish();
        }


    }
}