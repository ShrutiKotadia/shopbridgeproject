using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBridgeDAL.Inventory.Models
{
    public class InventoryDBLayer
    {
        private readonly ShopBridgeDbContext moDBContext;
        public InventoryDBLayer(ShopBridgeDbContext foDBContext)
        {
            moDBContext = foDBContext;
        }

        public void saveInventory(int? fiId, string fsName, string fsDesc, decimal? fdPrice, string fsFileName, out int fiSuccess)
        {
            SqlParameter loSuccess = new SqlParameter("@inSuccess", SqlDbType.Int) { Direction = ParameterDirection.Output };
            moDBContext.Database.ExecuteSqlInterpolated($"EXEC saveInventory @inId={fiId}, @stName={fsName},@stDescription={fsDesc},@dcPrice={fdPrice},@stImageName={fsFileName},@inSuccess={loSuccess} OUT");
            fiSuccess = Convert.ToInt32(loSuccess.Value);
        }
        public List<Inventory> getInventory(int? fiId)
        {
            return moDBContext.Set<Inventory>().FromSqlInterpolated($"EXEC getInventory @inId={fiId}").AsEnumerable().ToList();
        }

        public void deleteInventory(int fiId, out int fiSuccess)
        {
            SqlParameter loSuccess = new SqlParameter("@inSuccess", SqlDbType.Int) { Direction = ParameterDirection.Output };
            moDBContext.Database.ExecuteSqlInterpolated($"EXEC deleteInventory @inId={fiId},@inSuccess={loSuccess} OUT");
            fiSuccess = Convert.ToInt32(loSuccess.Value);
        }
    }
}
