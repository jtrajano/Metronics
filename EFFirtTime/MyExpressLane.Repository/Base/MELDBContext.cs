using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;

using MyExpressLane.Repository.Models;

namespace MyExpressLane.Repository.Base
{
    public class MELDBContext:DbContext
    {
        public MELDBContext()
        {

        }

        public DbSet<MELRequest> Request { get; set; }
        public DbSet<MELRequestType> RequestType { get; set; }
        public DbSet<AccessRevocation> AccessRevocation { get; set; }
        public DbSet<AccessRevocationDetails> AccessRevocationDetails { get; set; } 
        public DbSet<ServerRoomAccess> ServerRoomAccess { get; set; }
        public DbSet<MELUser> User { get; set; }
        public DbSet<MELProfile> Profile { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MELRequest>().ToTable("Request");
            modelBuilder.Entity<MELUser>().ToTable("User");
            modelBuilder.Entity<MELProfile>().ToTable("Profile");
            modelBuilder.Entity<MELRequestType>().ToTable("RequestType");
        }
    }
}
