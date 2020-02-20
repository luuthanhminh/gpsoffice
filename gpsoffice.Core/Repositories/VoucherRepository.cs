using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gpsoffice.Core.Data.DTOs;
using Realms;

namespace gpsoffice.Core.Repositories
{
    public class VoucherRepository : BaseRepository<VoucherDTO>
    {

        public override Task AddOrUpdateItems(IList<VoucherDTO> items)
        {
            return _realmInstance.WriteAsync((r) =>
            {
                foreach (var item in items)
                {
                    if (r.All<VoucherDTO>().Any(i => i.UUID == item.UUID))
                    {
                        r.Add(item, update: true);
                    }
                    else
                    {
                        r.Add(item);
                    }

                }
            });
        }
    }
}
