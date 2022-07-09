using GameTime.TimesDay.Abstract;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace GameTime.TimesDay.Model
{
    [CreateAssetMenu(menuName = "GameTime/Models/" + nameof(TimesDayModel), fileName = nameof(TimesDayModel))]
    internal class TimesDayModel : AbstractTimesDayModel
    {
        [SerializeField] private AbstractStateTimesDay[] gameStateTimesDay;

        private Dictionary<AllStateTimesDay, AbstractStateTimesDay> _stateDictionary = new Dictionary<AllStateTimesDay, AbstractStateTimesDay>();
        public override Dictionary<AllStateTimesDay, AbstractStateTimesDay> StateDictionary => _stateDictionary;

        internal override void Init(StateMachine stateMachine)
        {
            _stateDictionary = gameStateTimesDay.ToDictionary(key => key.KeyState, value => value);
            foreach (var state in gameStateTimesDay)
                state.Init(stateMachine);            
        }

    }
}
