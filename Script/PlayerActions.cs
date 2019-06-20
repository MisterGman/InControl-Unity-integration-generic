using System.Collections.Generic;
using InControl;
using UnityEngine;

namespace Input
{



	public class PlayerActions : PlayerActionSet
	{
		private ActionBindingSingle actionSO;
		private Dictionary<ActionEnum, PlayerAction> _allActions = new Dictionary<ActionEnum, PlayerAction>();
		private PlayerTwoAxisAction _move;
		private PlayerTwoAxisAction _mouseMove;


		public PlayerActions(ActionBindingSingle actionSO)
		{
			this.actionSO = actionSO;
		}
		
		
		public Dictionary<ActionEnum, PlayerAction> GetAllActions()
		{
			foreach (var action in actionSO.actions)
			{
				var temp = CreatePlayerAction(action.Key.ToString());

				if (action.Value.actionInput != InputControlType.None)
					temp.AddDefaultBinding(action.Value.actionInput);
				if (action.Value.keyInput != Key.None)
					temp.AddDefaultBinding(action.Value.keyInput);
				if (action.Value.mouseInput != Mouse.None)
					temp.AddDefaultBinding(action.Value.mouseInput);

				_allActions.Add(action.Key, temp);
			}
			
			return _allActions;
		}

		public PlayerTwoAxisAction GetMove()
		{
			_move = CreateTwoAxisPlayerAction(_allActions[ActionEnum.Left], 
				_allActions[ActionEnum.Right], 
				_allActions[ActionEnum.Down], 
				_allActions[ActionEnum.Up]);

			return _move;
		}
		
		public PlayerTwoAxisAction GetMouse()
		{
			_mouseMove = CreateTwoAxisPlayerAction(_allActions[ActionEnum.Left], 
				_allActions[ActionEnum.Right], 
				_allActions[ActionEnum.Down], 
				_allActions[ActionEnum.Up]);

			return _mouseMove;
		}
	}
}
