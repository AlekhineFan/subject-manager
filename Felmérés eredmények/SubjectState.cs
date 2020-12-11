namespace Felmérés_eredmények
{
    public class SubjectState
    {
        public int? SubjectId { get; set; }
        public string LastVisit { get; private set; }
        public int Stnr { get; set; }
        public int Atnr { get; set; }
        public int Galant { get; set; }
        public int TlrE { get; set; }
        public int TlrH { get; set; }
        public int Mar { get; set; }
        public int Szo { get; set; }
        public int Mor { get; set; }
        public int Left { get; set; }
        public int Right { get; set; }
        public int Niszt { get; set; }
        public string Notes { get; set; }
        public int Ejto { get; set; }
        public int Babinski { get; set; }
        public int Schilder { get; set; }

        public SubjectState(string lastVisit, int stnr, int atnr, int galant, int tlrE, int tlrH, int mar, int szo, int mor, int left, int right, int niszt, string notes, int ejto, int babinski, int schilder)
        {
            LastVisit = lastVisit;
            Stnr = stnr;
            Atnr = atnr;
            Galant = galant;
            TlrE = tlrE;
            TlrH = tlrH;
            Mar = mar;
            Szo = szo;
            Mor = mor;
            Left = left;
            Right = right;
            Niszt = niszt;
            Notes = notes;
            Ejto = ejto;
            Babinski = babinski;
            Schilder = schilder;

        }

        public SubjectState(int? subjectId, string lastVisit, int stnr, int atnr, int galant, int tlrE, int tlrH, int mar, int szo, int mor, int left, int right, int niszt, string notes, int ejto, int babinski, int schilder) :this(lastVisit, stnr, atnr, galant, tlrE, tlrH, mar, szo, mor, left, right, niszt, notes, ejto, babinski, schilder)
        {
            SubjectId = subjectId;
        }

        public override string ToString()
        {
            return $"{LastVisit}";
        }
    }
}
