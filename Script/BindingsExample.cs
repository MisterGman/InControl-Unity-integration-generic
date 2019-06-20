using System;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine.Serialization;

namespace Input
{
	using InControl;
	using UnityEngine;


	public class BindingsExample : MonoBehaviour
	{
		[SerializeField]
		private ActionBindingSingle actionSO;
		
		private PlayerActions _playerActions;
		private Dictionary<ActionEnum, PlayerAction> _allActions = new Dictionary<ActionEnum, PlayerAction>();

		private ActionEnum checker;
		void OnEnable()
		{
			_playerActions = new PlayerActions(actionSO);
			_allActions = _playerActions.GetAllActions();
		}
		
		void OnDisable() => _playerActions.Destroy();

		void Update()
		{
			GetKey();
		}

		void GetKey()
		{
			foreach (var action in _allActions)
			{
				if(action.Value.WasPressed)
					Debug.Log(action.Key);
			}
		}
	}
}

