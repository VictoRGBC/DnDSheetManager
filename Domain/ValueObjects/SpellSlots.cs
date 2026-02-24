namespace DnDSheetManager.Domain.ValueObjects
{
    public class SpellSlots
    {
        public int Level1Total { get; set; }
        public int Level1Used { get; set; }
        
        public int Level2Total { get; set; }
        public int Level2Used { get; set; }
        
        public int Level3Total { get; set; }
        public int Level3Used { get; set; }
        
        public int Level4Total { get; set; }
        public int Level4Used { get; set; }
        
        public int Level5Total { get; set; }
        public int Level5Used { get; set; }
        
        public int Level6Total { get; set; }
        public int Level6Used { get; set; }
        
        public int Level7Total { get; set; }
        public int Level7Used { get; set; }
        
        public int Level8Total { get; set; }
        public int Level8Used { get; set; }
        
        public int Level9Total { get; set; }
        public int Level9Used { get; set; }

        public int GetAvailable(int level)
        {
            return level switch
            {
                1 => Math.Max(0, Level1Total - Level1Used),
                2 => Math.Max(0, Level2Total - Level2Used),
                3 => Math.Max(0, Level3Total - Level3Used),
                4 => Math.Max(0, Level4Total - Level4Used),
                5 => Math.Max(0, Level5Total - Level5Used),
                6 => Math.Max(0, Level6Total - Level6Used),
                7 => Math.Max(0, Level7Total - Level7Used),
                8 => Math.Max(0, Level8Total - Level8Used),
                9 => Math.Max(0, Level9Total - Level9Used),
                _ => 0
            };
        }

        public bool UseSlot(int level)
        {
            if (GetAvailable(level) <= 0) return false;
            
            switch (level)
            {
                case 1: Level1Used++; return true;
                case 2: Level2Used++; return true;
                case 3: Level3Used++; return true;
                case 4: Level4Used++; return true;
                case 5: Level5Used++; return true;
                case 6: Level6Used++; return true;
                case 7: Level7Used++; return true;
                case 8: Level8Used++; return true;
                case 9: Level9Used++; return true;
                default: return false;
            }
        }

        public void RestoreSlot(int level)
        {
            switch (level)
            {
                case 1: if (Level1Used > 0) Level1Used--; break;
                case 2: if (Level2Used > 0) Level2Used--; break;
                case 3: if (Level3Used > 0) Level3Used--; break;
                case 4: if (Level4Used > 0) Level4Used--; break;
                case 5: if (Level5Used > 0) Level5Used--; break;
                case 6: if (Level6Used > 0) Level6Used--; break;
                case 7: if (Level7Used > 0) Level7Used--; break;
                case 8: if (Level8Used > 0) Level8Used--; break;
                case 9: if (Level9Used > 0) Level9Used--; break;
            }
        }

        public void LongRest()
        {
            Level1Used = 0;
            Level2Used = 0;
            Level3Used = 0;
            Level4Used = 0;
            Level5Used = 0;
            Level6Used = 0;
            Level7Used = 0;
            Level8Used = 0;
            Level9Used = 0;
        }
    }
}
