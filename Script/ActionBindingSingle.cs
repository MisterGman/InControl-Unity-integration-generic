using System.Collections.Generic;
using InControl;
using Input;
using UnityEngine;
using Sirenix.OdinInspector;

[CreateAssetMenu(fileName = "ActionBindSingle", menuName = "ActionBindSingle")]
public class ActionBindingSingle : SerializedScriptableObject
{
    //public PlayerAction up, down, left, right, shoot, ability1, ability2, ability3, ability4, start, back;

    [System.Serializable]
    public class ActionBindingElement
    {
        [EnumToggleButtons] public PCControlType controlType;

        [ShowIf("controlType", PCControlType.Gamepad)]
        public InputControlType actionInput;

        [ShowIf("controlType", PCControlType.Keyboard)]
        public Key keyInput;

        [ShowIf("controlType", PCControlType.Mouse)]
        public Mouse mouseInput;

    }

    public Dictionary<ActionEnum, ActionBindingElement> actions;

}

