namespace YgoLocals.Models.Match
{
    public class BaseMatchViewModel
    {
        public IList<MatchViewModel> UserActiveMatches { get; set; }

        public IList<MatchViewModel> AvaiableToJoin { get; set; }
    }
}
