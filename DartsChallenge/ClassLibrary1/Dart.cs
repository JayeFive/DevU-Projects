﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darts
{
    public class Dart
    {
        Random random = new Random();
        public int ScoreOfThrow;

        public void Throw()
        {
            int boardHitResult = random.Next(0, 20);
            ScoreOfThrow = boardHitResult;
            if (boardHitResult == 0) CheckForDoubleBullseye();
            else CheckForMultiplierRing();
        }

        public void CheckForDoubleBullseye()
        {
            if (random.Next(1, 100) > 95) ScoreOfThrow = 50;
            else ScoreOfThrow = 25;
        }

        public void CheckForMultiplierRing()
        {
            if (random.Next(1, 100) > 90) CheckForDoubleOrTripleRing();
        }

        public void CheckForDoubleOrTripleRing()
        {
            if (random.Next(0, 1) == 0) ScoreOfThrow *= 2;
            else ScoreOfThrow *= 3;
        }
    }
}
