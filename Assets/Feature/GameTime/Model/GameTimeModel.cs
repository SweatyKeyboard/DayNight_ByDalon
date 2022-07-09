using GameTime.Abstract;
using GameTime.Other;
using UnityEngine;

namespace GameTime.Models
{
    [CreateAssetMenu(menuName = "GameTime/Models/" + nameof(GameTimeModel), fileName = nameof(GameTimeModel))]
    internal class GameTimeModel : AbstractGameTimeModel
    {
        [SerializeField] private DataTime time;
        public override DataTime Time => time;

        [SerializeField] private int defaultDay = 1;
        [SerializeField] private int defaultHour = 6;
        [SerializeField] private int defaultMinute;
        [SerializeField] private int defaultSeconds;
        [Space]
        [SerializeField] private int defaultStepGameSeconds = 1;
        [SerializeField] private float defaultStepRealSeconds = 1;
        [Space]
        [SerializeField] private int countHourInDay = 60;
        [SerializeField] private int countMinuteInHour = 60;
        [SerializeField] private int countSecondInMinute = 60;

        private int _stepGameSeconds;
        public override int StepGameSeconds
        {
            get => _stepGameSeconds;
            set => _stepGameSeconds = value;
        }

        private float _stepRealSeconds;
        public override float StepRealSeconds => _stepRealSeconds;

        private void OnEnable()
        {
            time = new DataTime(defaultHour, defaultMinute, defaultSeconds, defaultDay, countHourInDay, countMinuteInHour, countSecondInMinute);
            _stepGameSeconds = defaultStepGameSeconds;
            _stepRealSeconds = defaultStepRealSeconds;
        }
    }
}
