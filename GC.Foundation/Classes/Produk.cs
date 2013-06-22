// ----------------------------------------------------------------------
// WCF Going Crazy
// Author : Cokorda Smara
// Date   : 22 Juni 2013
// Time   : 03:02
// Url    : https://www.facebook.com/cokde.smara
// Copyright 2013 WCF Going Crazy. All Right Reserved.
// ------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace GC.Foundation
{
    [DataContract]
    public class ProdukModel
    {
        [DataMember(Order = 1, EmitDefaultValue = false)]
        public Int32 IDProduk { get; set; }

        [DataMember(Order = 2, EmitDefaultValue = false)]
        public String NamaProduk { get; set; }

        [DataMember(Order = 3, EmitDefaultValue = false)]
        public Decimal HargaBeliProduk { get; set; }

        [DataMember(Order = 3, EmitDefaultValue = false)]
        public Decimal HargaJualProduk { get; set; }
    }

    public class ProdukLogic
    {
        public ProdukLogic() { }

        private ProdukModel[] DataProduk = new ProdukModel[] 
        { 
            new ProdukModel { IDProduk = 1, NamaProduk = "Mouse Wifi Logitech", HargaBeliProduk = 200000, HargaJualProduk = 250000 }, 
            new ProdukModel { IDProduk = 2, NamaProduk = "Monitor LCD LG", HargaBeliProduk = 2000000, HargaJualProduk = 2500000  }, 
            new ProdukModel { IDProduk = 3, NamaProduk = "Laptop Toshiba", HargaBeliProduk = 6000000, HargaJualProduk = 6500000  } 
        };

        public List<ProdukModel> TampilProduk(String NamaProduk)
        {
            var Query = DataProduk.Where(p => p.NamaProduk.Contains(NamaProduk)).ToList();
            return Query;
        }

        public ProdukModel GetProduk(Int32 IDProduk)
        {
            var Query = DataProduk.FirstOrDefault(p => p.IDProduk == IDProduk);
            return Query;
        }
    }
}
