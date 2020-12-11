using System;
using System.Linq;

namespace Felmérés_eredmények
{
    class Evaluate
    {
        public static SubjectState Difference(Subject subject)
        {
            SubjectState current = subject.SubjectStates.LastOrDefault();
            SubjectState before = subject.SubjectStates[subject.SubjectStates.Count - 2];

            SubjectState difference = new SubjectState(
                current.LastVisit,
                current.Stnr - before.Stnr,
                current.Atnr - before.Atnr,
                current.Galant - before.Galant,
                current.TlrE - before.TlrE,
                current.TlrH - before.TlrH,
                current.Mar - before.Mar,
                current.Szo - before.Szo,
                current.Mor - before.Mor,
                current.Left - before.Left,
                current.Right - before.Right,
                current.Niszt - before.Niszt,
                current.Notes,
                current.Ejto - before.Ejto,
                current.Babinski - before.Babinski,
                current.Schilder - before.Schilder
                );

            return difference;
        }

        public static double PercentageDiff(Subject subject)
        {
            SubjectState current = subject.SubjectStates.LastOrDefault();
            SubjectState before = subject.SubjectStates[subject.SubjectStates.Count - 2];

            double oneBeforeLastPercentage =
                (before.Stnr +
                 before.Atnr +
                 before.Galant +
                 before.TlrH +
                 before.TlrE +
                 before.Mar +
                 before.Szo +
                 before.Mor +
                 before.Niszt +
                 before.Ejto +
                 before.Babinski +
                 before.Schilder) / 24.00;

            double currentPercentage =
                (current.Stnr +
                 current.Atnr +
                 current.Galant +
                 current.TlrH +
                 current.TlrE +
                 current.Mar +
                 current.Szo +
                 current.Mor +
                 current.Niszt +
                 current.Ejto +
                 current.Babinski +
                 current.Schilder) / 24.00;

            return Math.Round((currentPercentage - oneBeforeLastPercentage), 2) * 100;
        }
    }
}
