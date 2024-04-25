namespace ProjectPlanner.Utilities
{
    public class MyComparer : IComparer<string>
    {
        public int Compare(string? x, string? y)
        {
            if(x == SD.status_progress)
            {
                return -1;
            }

            if(x == SD.status_done)
            {
                return 1;
            }

            if(x == SD.status_new && y == SD.status_done)
            {
                return -1;
            }

            if (x == SD.status_waiting && y == SD.status_done)
            {
                return -1;
            }
            
            if(x == SD.status_new && y == SD.status_waiting)
            {
                return -1;
            }
            return 0;
        }
    }
}
