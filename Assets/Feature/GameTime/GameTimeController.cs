using GameTime.Abstract;
using GameTime.TimesDay.Abstract;
using GameTime.TimesDay;
using UnityEngine;

namespace GameTime
{
    internal class GameTimeController : AbstractGameTimeController
    {
        [SerializeField] private AbstractTimeDayController timeDayController;

        private float _deltaSeconds;
        private bool _isPause;

        private void Awake()
        {
            Init();
        }

        private void Update()
        {
            UpdateTimeDay();
#if UNITY_EDITOR
            if (Input.GetKeyDown(KeyCode.Q))
                SetPauseTime(true);
            if (Input.GetKeyDown(KeyCode.W))
                SetPauseTime(false);
            if (Input.GetKeyDown(KeyCode.D))
                ChangeTime(2);
            if (Input.GetKeyDown(KeyCode.Z))
                ChangeTime(6, 0, 0);
            if (Input.GetKeyDown(KeyCode.X))
                ChangeTime(12, 0, 0);
            if (Input.GetKeyDown(KeyCode.C))
                ChangeTime(18, 0, 0);
            if (Input.GetKeyDown(KeyCode.V))
                ChangeTime(24, 0, 0);
#endif
        }
        protected override void SetPauseTime(bool isPause) => _isPause = isPause;
        protected override void ChangeTime(int day) => model.Time.ChengeDay(day);
        protected override void ChangeTime(int hour, int minute, int second) => model.Time.ChengeTime(hour, minute, second);
        protected override void ChangeTime(int hour, int minute, int second, int day)
        {
            ChangeTime(day);
            ChangeTime(hour, minute, second);
        }

        private void UpdateTimeDay()
        {
            if (_isPause) return;

            if (_deltaSeconds >= model.StepRealSeconds)
            {
                model.Time.AddSeconds(model.StepGameSeconds);
                _deltaSeconds -= model.StepRealSeconds;
            }
            _deltaSeconds += Time.deltaTime;
        }
        private void ShowTimeView(int hour, int minute, int seconds) => view.ShowTime(hour, minute, seconds);
        private void ShowDayView(int day) => view.ShowDay(day);
        private void ChangeStateTimesDay(int hour, int minute, int seconds) => timeDayController.ChangeTimeDay(hour, minute, seconds);

        private void Init()
        {
            model.Time.onChangeTime += ChangeStateTimesDay;
            model.Time.onChangeTime += ShowTimeView;
            model.Time.onChangeDay += ShowDayView;
        }

        private void OnDestroy()
        {
            model.Time.onChangeTime -= ChangeStateTimesDay;
            model.Time.onChangeTime -= ShowTimeView;
            model.Time.onChangeDay -= ShowDayView;
        }
    }
}