using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EntityFramework.Patterns;
using EntityFramework6.Repository;

namespace EntityFramework6.MVC.Models
{
    public class HomeRepository: IUnitOfWork
    {
        private DbContextAdapter Adapter;
        public IRepository<Product> ProductRepo { get; set; }
        public IRepository<ProductCategory> CatRepo { get; set; }
        public UnitOfWork Unit_OfWork { get; set; }
        
        public HomeRepository()
        {
            Adapter = new DbContextAdapter(ContextFactory.GetContext(ContextFactory.DBKey.SALES));
            Unit_OfWork = new UnitOfWork(Adapter);
            ProductRepo = new Repository<Product>(Adapter);
            CatRepo = new Repository<ProductCategory>(Adapter);
        }
        public void Commit() {
            Unit_OfWork.Commit();
        }
        
        
        

    }
}