using System;
using UnityEngine;

namespace GameTime.Other
{
    [Serializable]
    public class DataTime
    {
        private DataTime()
        {
        }
        public DataTime(int hour, int minute, int seconds)
        {
            _hour = hour;
            _minute = minute;
            _seconds = seconds;
        }
        public DataTime(int hour, int minute, int seconds, int countHourInDay, int countMinuteInHour, int countSecondInMinute) : this(hour, minute, seconds)
        {
            _countHourInDay = countHourInDay;
            _countMinuteInHour = countMinuteInHour;
            _countSecondInMinute = countSecondInMinute;
        }
        public DataTime(int hour, int minute, int seconds, int day) : this(hour, minute, seconds) => _day = day;
        public DataTime(int hour, int minute, int seconds, int day, int countHourInDay, int countMinuteInHour, int countSecondInMinute) :
            this(hour, minute, seconds, countHourInDay, countMinuteInHour, countSecondInMinute) => _day = day;

        #region Private
       [SerializeField] private int _day = 1;
        [SerializeField] private int _hour;
        [SerializeField] private int _minute;
        [SerializeField] private int _seconds;

        private readonly int _countHourInDay = 24;
        private readonly int _countMinuteInHour = 60;
        private readonly int _countSecondInMinute = 60;
        #endregion

        #region Property
        public int Day
        {
            get => _day;
            private set
            {
                _day = value;
                onChangeDay.Invoke(value);
            }
        }
        public int Hour
        {
            get => _hour;
            private set
            {
                while (value >= _countHourInDay)
                {
                    value -= _countHourInDay;
                    Day++;
                }
                _hour = value;
            }
        }
        public int Minute
        {
            get => _minute;
            private set
            {
                while (value >= _countMinuteInHour)
                {
                    value -= _countMinuteInHour;
                    Hour++;
                }
                _minute = value;
            }
        }
        public int Seconds
        {
            get => _seconds;
            private set
            {
                while (value >= _countSecondInMinute)
                {
                    value -= _countSecondInMinute;
                    Minute++;
                }
                _seconds = value;
                onChangeTime.Invoke(Hour, Minute, value);
            }
        }
        #endregion

        public event Action<int> onChangeDay = delegate { };
        public event Action<int, int, int> onChangeTime = delegate { };

        public void AddSeconds(int seconds) => Seconds += seconds;
        public void ChengeDay(int day) => Day = day;
        public void ChengeTime(int hour, int minute, int seconds)
        {
            Hour = hour;
            Minute = minute;
            Seconds = seconds;
        }
    }
}
