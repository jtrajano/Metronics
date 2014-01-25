using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyExpressLane.Repository.Base;
using MyExpressLane.Repository.Models;



namespace MyExpressLane.Web.Repository
{
    public class RequestRepository :RepositoryBase<MELDBContext>
    {
       
        public IQueryable<MELRequest> GetAllRequest() 
        {
            IQueryable<MELRequest> r = GetList<MELRequest>();
            return r;
        }
     
       
        
        
    }
}
