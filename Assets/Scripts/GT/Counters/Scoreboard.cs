using System;

namespace GT.Counters
{
    public abstract class Scoreboard
    {
        private int _score;
        private readonly int _minScore;
        private readonly int _maxScore;

        protected Scoreboard(int def, int min, int max)
        {
            _score = def;
            _minScore = min;
            _maxScore = max;
        }

        public int Get()
        {
            return _score;
        }

        public void Modify(int delta)
        {
            _score += delta;
            _score = Math.Max(_score, _minScore);
            _score = Math.Min(_score, _maxScore);
        }
    }
}