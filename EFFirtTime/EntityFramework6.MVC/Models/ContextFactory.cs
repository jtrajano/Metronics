using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EntityFramework6.Repository;
using System.Data.Entity;


namespace EntityFramework6.MVC.Models
{
    public class ContextFactory
    {
        public enum DBKey
	    {
	         SALES,
            OTHERS
	    }
        public static DbContext GetContext(DBKey index) {

            string key = GetKey(index);
            DbContext dc = (ProductContext)HttpContext.Current.Items[key];

            if(dc==null){
                dc = new ProductContext();
                HttpContext.Current.Items.Add(key,dc);
            }
            
            return dc;
        }
        public static string GetKey(DBKey index)
        {
            switch (index)
            {
                    
                case DBKey.SALES:
                    return "__SALES_" + HttpContext.Current.GetHashCode().ToString("x");
                //case MEL:
                //    return "__MELDC_" + HttpContext.Current.GetHashCode().ToString("x") + Thread.CurrentContext.ContextID.ToString();
                //case SAM:
                //    return "__SAMDC_" + HttpContext.Current.GetHashCode().ToString("x") + Thread.CurrentContext.ContextID.ToString();
                //case DCNPINR:
                //    return "__DCNPINR_" + HttpContext.Current.GetHashCode().ToString("x") + Thread.CurrentContext.ContextID.ToString();
                default:
                    return string.Empty;

            }
        }
    }
}