using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using MyExpressLane.Repository.Models;
namespace MyExpressLane.Repository.Base
{
    public class MELDBContextCustomInitializer:IDatabaseInitializer<MELDBContext>
    {
        public void InitializeDatabase(MELDBContext context) {
            if (context.Database.Exists())
            {
                if (!context.Database.CompatibleWithModel(true))
                {
                    context.Database.Delete();
                    RecreateDatabase(context);
                }
            }
            else
            { 
                RecreateDatabase(context); 
            }
           
        }
        private void RecreateDatabase(MELDBContext context) {
            
            context.Database.Create();
            context.RequestType.Add(new MELRequestType { description = "Access Revocaton" });
            context.RequestType.Add(new MELRequestType { description = "Server Access" });
            context.SaveChanges();
          
        }
    }
}