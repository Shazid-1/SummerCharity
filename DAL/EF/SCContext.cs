using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF
{
    public class SCContext: DbContext
    {
        public DbSet<Creator> Creators {  get; set; }
        public DbSet<Membership> Memberships {  get; set; }

        public DbSet<Admin> Admins { get; set; }
        public DbSet<Donator> Donators { get; set; }
        public DbSet<Event> Events { get; set; }

        public DbSet<EventDonator> EventDonators { get; set; }
    }
}
