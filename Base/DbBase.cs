using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Configuration;
using System.Text;
using System.Threading.Tasks;
using VilasLab.Models;

namespace VilasLab.Base
{
    public partial class DbBase : DbContext
    {
        //public DbBase(string connString)
        //: base(connString)
        //{
        //}
        public DbSet<BeanCustomer> BeanCustomer { get; set; }
        public DbSet<BeanFactory> BeanFactory { get; set; }
        public DbSet<BeanIngredient> BeanIngredient { get; set; }
        public DbSet<BeanPermission> BeanPermission { get; set; }
        public DbSet<BeanRequirement> BeanRequirement { get; set; }
        public DbSet<BeanResult> BeanResult { get; set; }
        public DbSet<BeanSample> BeanSample { get; set; }
        public DbSet<BeanSpecies> BeanSpecies { get; set; }
        public DbSet<BeanTargetTest> BeanTargetTest { get; set; }
        public DbSet<BeanTestType> BeanTestType { get; set; }
        public DbSet<BeanDocument> BeanDocument { get; set; }
        public DbSet<BeanDocumentSigner> BeanDocumentSigner { get; set; }
        public DbSet<BeanTemplate> BeanTemplate { get; set; }
        public DbSet<BeanField> BeanField { get; set; }
        public DbSet<BeanNotify> BeanNotify { get; set; }
        public DbSet<BeanClient> BeanClient { get; set; }
        public DbSet<BeanUrlSave> BeanUrlSave { get; set; }
        public DbSet<BeanTrackingError> BeanTrackingError { get; set; }
        public DbSet<BeanMachine> BeanMachine { get; set; }
       
    }

    public class DbBase<T> where T : class
    {
        public DbSet<T> DBBase { get; set; }
        public virtual List<T> SelectAll()
        {
            using (var context = new DbBase())
            {
                return context.Set<T>().ToList();
            }
        }
        public T SelectByID(object ID)
        {
            using (var context = new DbBase())
            {
                return context.Set<T>().Find(ID);
            }
        }

        public virtual void Insert(T entity)
        {
            using (var context = new DbBase())
            {
                context.Entry(entity).State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public virtual void Update(T entity)
        {
            using (var context = new DbBase())
            {
                context.Entry(entity).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public virtual void Delete(T entity)
        {
            using (var context = new DbBase())
            {
                context.Entry(entity).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
    }
}
