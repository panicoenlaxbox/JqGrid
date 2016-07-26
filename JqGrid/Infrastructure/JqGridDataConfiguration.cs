namespace JqGrid.Infrastructure
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>http://www.trirand.com/jqgridwiki/doku.php?id=wiki:retrieving_data</remarks>
    public class JqGridDataConfiguration
    {
        public JqGridDataConfiguration()
        {
            Root = "rows";
            Total = "total";
            Page = "page";
            Records = "records";
            Cell = "cell";
            Id = "id";
            IncludeId = true;
            ExcludeIdFromCell = true;
        }

        public string Root { get; set; }
        public string Total { get; set; }
        public string Page { get; set; }
        public string Records { get; set; }
        public string Cell { get; set; }
        public string Id { get; set; }
        public bool IncludeId { get; set; }
        public bool ExcludeIdFromCell { get; set; }
    }
}