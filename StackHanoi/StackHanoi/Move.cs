namespace StackHanoi
{
    public class Move
    {
        public Move(Tower from, Tower to)
        {
            From = from;
            To = to;
        }

        public Tower From { get; set; }
        public Tower To { get; set; }
    }
}