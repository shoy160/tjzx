using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace Tjzx.Official.Models.Concrete
{
    public class DataPage
    {
        public string Table { get; set; }

        public string PrimaryKey { get; set; }

        public string Sort { get; set; }

        public int PageIndex { get; set; }

        public int PageSize { get; set; }

        public string Fields { get; set; }

        public string Filter { get; set; }

        public string Group { get; set; }
    }

    public static class EFDbContextExpand
    {
        public static IEnumerable<T> Paging<T>(this EFDbContext db, DataPage page, out int totalCount)
        {
            const string sql =
                "sp_Paging @Tables,@PrimaryKey,@Sort,@pageindex,@PageSize,@Fields,@Filter,@Group,@TotalCount OUT";
            var outParam = new SqlParameter
                {
                    ParameterName = "TotalCount",
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Output,
                    Value = 0
                };

            IEnumerable<T> list = db.Database.SqlQuery<T>(sql,
                                                          new SqlParameter("Tables", page.Table),
                                                          new SqlParameter("PrimaryKey", page.PrimaryKey),
                                                          new SqlParameter("Sort", page.Sort),
                                                          new SqlParameter("pageindex", page.PageIndex),
                                                          new SqlParameter("PageSize", page.PageSize),
                                                          new SqlParameter("Fields", page.Fields),
                                                          new SqlParameter("Filter", page.Filter),
                                                          new SqlParameter("Group", page.Group),
                                                          outParam
                ).ToList();
            totalCount = (int) outParam.Value;
            return list;
        }
    }
}
