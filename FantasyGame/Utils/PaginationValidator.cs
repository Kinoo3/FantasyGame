namespace FantasyGame.Utils
{
    public class PaginationValidator
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int Skip { get; set; }
        public int Take { get; set; }

        public PaginationValidator(int page, int pageSize) 
        {
            if (page <= 0) this.Page = 1;
            else this.Page = page;

            if (pageSize <= 0) this.PageSize = 10;
            else this.PageSize = pageSize;

            this.Skip = (this.Page - 1) * this.PageSize;
            this.Take = this.PageSize;
        }
    }
}
