// Copyright (c) 2015 - 2018 Doozy Entertainment / Marlink Trading SRL. All Rights Reserved.
// This code can only be used under the standard Unity Asset Store End User License Agreement
// A Copy of the EULA APPENDIX 1 is available at http://unity3d.com/company/legal/as_terms

#if dUI_PlayMaker
using UnityEngine;
using HutongGames.PlayMaker;
using DoozyUI;

namespace HutongGames.PlayMaker.Actions
{
    [ActionCategory("DoozyUI")]
    [Tooltip("Sends a Game Event")]
    public class SendGameEvent : FsmStateAction
    {
        public bool debug = false;

        [RequiredField]
        public FsmString gameEvent;

        public override void Reset()
        {
            gameEvent = new FsmString { UseVariable = false };
        }

        public override void OnEnter()
        {
            UIManager.SendGameEvent(gameEvent.Value);
            if (debug) { Debug.Log("[DoozyUI] - Playmaker - State Name [" + State.Name + "] - Sent game event message - [" + gameEvent.Value + "]"); }
            Finish();
        }
    }
}
#endif