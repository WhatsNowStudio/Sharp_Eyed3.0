using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;
using System.Collections.Generic;

namespace HutongGames.PlayMaker.Actions
{
    [ActionCategory("AssetBundle")]
    [Tooltip("從ABs找到並實例化物件")]

    public class PlayMakerLoadAllAssetsFromAbs : FsmStateAction
    {
        [RequiredField]
        [Tooltip("必填條件-Abs")]
        [ObjectType(typeof(AssetBundle))]
        public FsmObject Abs;


        [ActionSection("Results")]
        [UIHint(UIHint.Variable)]
        [ArrayEditor(VariableType.GameObject)]
        public FsmArray Getgameobjects;


        [ActionSection("Events")]
        [Tooltip("讀取成功發出Done")]
        public FsmEvent isDone;
        [Tooltip("讀取成功發出Error")]
        public FsmEvent isError;
        public Slider loadSlider;
        private Coroutine Start;
        public List<AssetBundle> bundles = new List<AssetBundle>();

        public FsmInt version = 1;
        public PlayMakerMountAbsFromFile FilePath;
        AssetBundleCreateRequest m_Request = null;
        AssetBundleRequest m_AssetRequest = null;
        AssetBundle m_AssetBundle = null;
        private static PlayMakerLoadAllAssetsFromAbs instance;
        public static PlayMakerLoadAllAssetsFromAbs GetInstance()
        {
            return instance;

        }

        /// <summary>
        /// Awake is called when the script instance is being loaded.
        /// </summary>
        void Awake()
        {

        }

        public override void Reset()
        {

        }

        public override void OnEnter()
        {
            m_AssetBundle = (Abs.Value as AssetBundle);
            string[] assets = m_AssetBundle.GetAllAssetNames();
            var GOArray = new GameObject[assets.Length];

            for (int i = 0; i < assets.Length; i++)
            {
                m_AssetRequest = m_AssetBundle.LoadAssetAsync(assets[i]);

                GOArray[i] = m_AssetRequest.asset as GameObject;

                GameObject.Instantiate(GOArray[i]);
            }
            
            Getgameobjects.Values = GOArray;



        }

        public override void OnUpdate()
        {


        }
    }
}
