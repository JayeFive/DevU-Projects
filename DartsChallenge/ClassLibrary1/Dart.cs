using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darts
{
    public class Dart
    {
        public Dart()
        {
            IsOuterRing = false;
            IsInnerRing = false;
            IsBullseye = false;
            IsDoubleBullseye = false;
        }

        public int NumberLandedOn { get; set; }
        public bool IsOuterRing { get; set; }
        public bool IsInnerRing { get; set; }
        public bool IsBullseye { get; set; }
        public bool IsDoubleBullseye { get; set; }


        Random random = new Random();

        public void Throw()
        {
            NumberLandedOn = random.Next(0, 20);
            if (NumberLandedOn == 0) IsSingleOrDoubleBullseye();
            else CheckForRing();
        }

        internal void IsSingleOrDoubleBullseye()
        {
            if (random.Next(1, 100) < 5) IsBullseye = true;
            else IsDoubleBullseye = true;
        }

        internal void CheckForRing()
        {
            if (random.Next(1, 100) < 10) IsInnerOrOuterRing();
        }

        internal void IsInnerOrOuterRing()
        {
            if (random.Next(0, 1) == 0) IsOuterRing = true;
            else IsInnerRing = true;
        }

        public void ResetDart()
        {
            IsBullseye = false;
            IsDoubleBullseye = false;
            IsInnerRing = false;
            IsOuterRing = false;
        }
    }
}
