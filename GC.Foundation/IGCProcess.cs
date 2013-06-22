// ----------------------------------------------------------------------
// WCF Going Crazy
// Author : Cokorda Smara
// Date   : 22 Juni 2013
// Time   : 03:06
// Url    : https://www.facebook.com/cokde.smara
// Copyright 2013 WCF Going Crazy. All Right Reserved.
// ------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace GC.Foundation.ServiceContract
{
    [ServiceContract(Namespace = "https://www.facebook.com/cokde.smara")]
    public interface IGCProcess
    {
        [OperationContract(Name = "TampilProduk")]
        [WebInvoke(Method = "*", UriTemplate = "/produk.{Format}?aksi=tampil&produk={NamaProduk}&user={User}&key={ApiKey}", BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        ProdukModel[] TampilProduk(String Format, String NamaProduk, String User, String ApiKey);

        [OperationContract(Name = "GetProduk")]
        [WebInvoke(Method = "*", UriTemplate = "/produk.{Format}?aksi=get&id={IDProduk}&user={User}&key={ApiKey}", BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        ProdukModel GetProduk(String Format, String IDProduk, String User, String ApiKey);
    }
}
