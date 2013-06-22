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
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.ServiceModel.Activation;
using GC.Foundation.ServiceContract;

namespace GC.Foundation.ServiceImplementation
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(Namespace = "https://www.facebook.com/cokde.smara")]
    public class GCProcess : IGCProcess
    {
        ProdukModel[] IGCProcess.TampilProduk(String Format, String NamaProduk, String User, String ApiKey)
        {
            try
            {
                if (!String.IsNullOrWhiteSpace(Format))
                {
                    //Jika formatnya XML
                    if (Format.Equals("xml", StringComparison.OrdinalIgnoreCase))
                        WebOperationContext.Current.OutgoingResponse.Format = WebMessageFormat.Xml;
                    //Jika formatnya JSON
                    else if (Format.Equals("json", StringComparison.OrdinalIgnoreCase))
                        WebOperationContext.Current.OutgoingResponse.Format = WebMessageFormat.Json;
                    else
                        throw new WebFaultException(HttpStatusCode.BadRequest);
                }

                if (WebOperationContext.Current.IncomingRequest.Method.Equals("GET", StringComparison.OrdinalIgnoreCase) || WebOperationContext.Current.IncomingRequest.Method.Equals("POST", StringComparison.OrdinalIgnoreCase))
                {
                    if (new Auth().Autentikasi(User, ApiKey))
                        return new ProdukLogic().TampilProduk(NamaProduk).ToArray();
                    else
                        throw new WebFaultException(HttpStatusCode.Unauthorized);
                }
                else
                {
                    throw new WebFaultException(HttpStatusCode.MethodNotAllowed);
                }
            }
            catch (WebFaultException Ex)
            {
                if (Ex.StatusCode == HttpStatusCode.BadRequest)
                    throw new WebFaultException<Pesan>(new Pesan() { Error = String.Format("Tipe format .{0} tidak valid.", Format) }, HttpStatusCode.BadRequest);
                else if (Ex.StatusCode == HttpStatusCode.Unauthorized)
                    throw new WebFaultException<Pesan>(new Pesan() { Error = "Autentikasi tidak valid." }, HttpStatusCode.Unauthorized);
                else if (Ex.StatusCode == HttpStatusCode.MethodNotAllowed)
                    throw new WebFaultException<Pesan>(new Pesan() { Error = String.Format("Method {0} tidak valid.", WebOperationContext.Current.IncomingRequest.Method) }, HttpStatusCode.MethodNotAllowed);
                else
                    throw new WebFaultException<Pesan>(new Pesan() { Error = Ex.Message }, HttpStatusCode.InternalServerError);
            }
            catch (Exception Ex)
            {
                throw new WebFaultException<Pesan>(new Pesan() { Error = Ex.Message }, HttpStatusCode.InternalServerError);
            }
        }

        ProdukModel IGCProcess.GetProduk(String Format, String IDProduk, String User, String ApiKey)
        {
            try
            {
                if (!String.IsNullOrWhiteSpace(Format))
                {
                    //Jika formatnya XML
                    if (Format.Equals("xml", StringComparison.OrdinalIgnoreCase))
                        WebOperationContext.Current.OutgoingResponse.Format = WebMessageFormat.Xml;
                    //Jika formatnya JSON
                    else if (Format.Equals("json", StringComparison.OrdinalIgnoreCase))
                        WebOperationContext.Current.OutgoingResponse.Format = WebMessageFormat.Json;
                    else
                        throw new WebFaultException(HttpStatusCode.BadRequest);
                }

                if (WebOperationContext.Current.IncomingRequest.Method.Equals("GET", StringComparison.OrdinalIgnoreCase) || WebOperationContext.Current.IncomingRequest.Method.Equals("POST", StringComparison.OrdinalIgnoreCase))
                {
                    if (new Auth().Autentikasi(User, ApiKey))
                        return new ProdukLogic().GetProduk(Convert.ToInt32(IDProduk));
                    else
                        throw new WebFaultException(HttpStatusCode.Unauthorized);
                }
                else
                {
                    throw new WebFaultException(HttpStatusCode.MethodNotAllowed);
                }
            }
            catch (WebFaultException Ex)
            {
                if (Ex.StatusCode == HttpStatusCode.BadRequest)
                    throw new WebFaultException<Pesan>(new Pesan() { Error = String.Format("Tipe format .{0} tidak valid.", Format) }, HttpStatusCode.BadRequest);
                else if (Ex.StatusCode == HttpStatusCode.Unauthorized)
                    throw new WebFaultException<Pesan>(new Pesan() { Error = "Autentikasi tidak valid." }, HttpStatusCode.Unauthorized);
                else if (Ex.StatusCode == HttpStatusCode.MethodNotAllowed)
                    throw new WebFaultException<Pesan>(new Pesan() { Error = String.Format("Method {0} tidak valid.", WebOperationContext.Current.IncomingRequest.Method) }, HttpStatusCode.MethodNotAllowed);
                else
                    throw new WebFaultException<Pesan>(new Pesan() { Error = Ex.Message }, HttpStatusCode.InternalServerError);
            }
            catch (Exception Ex)
            {
                throw new WebFaultException<Pesan>(new Pesan() { Error = Ex.Message }, HttpStatusCode.InternalServerError);
            }
        }
    }
}
