using System;
using Realms;

namespace gpsoffice.Core.Data.DTOs
{
    public class VoucherDTO : RealmObject
    {
        [PrimaryKey]
        public string UUID { get; set; }

        public VoucherDTO()
        {
            UUID = Guid.NewGuid().ToString();
        }

        public int Autoid { get; set; }


        public string VoucherNumber { get; set; }


        public string VoucherDate { get; set; }


        public string UserName { get; set; }


        public string Narration { get; set; }
    }
}
