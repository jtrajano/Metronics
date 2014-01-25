using System;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Data.Entity;
using System.Web;
using MyExpressLane.Repository.Models;


namespace MyExpressLane.Web.Repository
{
    public class RepositoryBase<C> :IDisposable
        where C : DbContext, new()
    {
        private C _DataContext;

        public virtual C DataContext 
        {
            get 
            {
                string ockey = "mel_" + HttpContext.Current.GetHashCode().ToString("x");
                if (!HttpContext.Current.Items.Contains(ockey)) {
                    _DataContext = new C();
                    HttpContext.Current.Items.Add("mel", _DataContext);
                   
                }
                this.AllowSerialization = true;
                return _DataContext;
            }
        }
        public virtual bool AllowSerialization 
        {
            get {
                return _DataContext.Configuration.ProxyCreationEnabled;

            }
            set {
                _DataContext.Configuration.ProxyCreationEnabled = !value;
            }
        
        }
        public virtual T Get<T>(Expression<Func<T,bool>> predicate) where T: class 
        {
            if (predicate != null)
            {
                using (DataContext)
                {
                    return DataContext.Set<T>().Where(predicate).SingleOrDefault();
                }

            }
            else 
            {
                throw new ApplicationException("Predicate value must be passed to Get<T>.");

            }
        }
        public virtual IQueryable<T> GetList<T>(Expression<Func<T, bool>> predicate) where T:class 
        {
            try
            {
                return DataContext.Set<T>().Where(predicate);
            }
            catch (Exception ex)
            {
                
                
            }
            return null;
        
        }
       
        public virtual IQueryable<T> GetList<T, TKey>(Expression<Func<T, bool>> predicate,
            Expression<Func<T, TKey>> orderBy) where T : class
        {
            try
            {
                return GetList(predicate).OrderBy(orderBy);
            }
            catch (Exception ex)
            {
                
                throw;
            }
            return null;
        }
        public virtual IQueryable<T> GetList<T, TKey>(Expression<Func<T, TKey>> orderBy) where T : class 
        {
            try
            {
                return GetList<T>().OrderBy(orderBy);
            }
            catch (Exception ex)
            {
                
                throw;
            }
        }
        public virtual IQueryable<T> GetList<T>() where T : class
        {
            try
            {
                return DataContext.Set<T>();
            }
            catch (Exception ex)
            {
                
                
            }
            return null;
        }
        public virtual OperationStatus Save<T>(T entity) where T : class 
        {
            OperationStatus opStatus = new OperationStatus();
            try
            {
                opStatus.Status = DataContext.SaveChanges() > 0;
            }
            catch (Exception ex)
            {

                opStatus = OperationStatus.CreateFromException("Error saving " + typeof(T) + ".", ex);

            }
            return opStatus;
                 
        }
        public virtual OperationStatus Update<T>(T entity, params string[] propsToUpdate)where T: class
        {
            OperationStatus opStatus = new OperationStatus { Status = true };
            try
            {
                DataContext.Set<T>().Attach(entity);
                opStatus.Status = DataContext.SaveChanges() > 0;
            }
            catch (Exception ex)
            {

                opStatus = OperationStatus.CreateFromException("Error updating " + typeof(T) + ".", ex);
            }
            return opStatus;
        }
        public OperationStatus ExecuteStoreCommand(string cmdText, params object[] parameters) 
        {
            var opStatus = new OperationStatus { Status = true };
            try
            {
                opStatus.RecordsAffected = DataContext.Database.ExecuteSqlCommand(cmdText, parameters);
            }
            catch (Exception ex)
            {

                OperationStatus.CreateFromException("Error executing store command: ", ex);
            }
            return opStatus;
        }

        public void Dispose() 
        {
            if (DataContext != null) DataContext.Dispose();
        }

       
        
        
    }
}
