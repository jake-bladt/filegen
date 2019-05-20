using System;

namespace genfiles
{
    public class RandomCharCountGenerator
    {
        protected readonly int _min;
        protected readonly int _max;
        protected readonly int _targetMean;
        protected readonly Random _rng;

        public RandomCharCountGenerator(int min, int max, int targetMean)
        {
            _min = min;
            _max = max;
            _targetMean = targetMean;
            _rng = new Random();
        }

        public int GetCharCount()
        {
            var dbl = _rng.NextDouble();
            var topCount = dbl * (_max - _min);
            return (int) (topCount + _min);
        }

    }
}
