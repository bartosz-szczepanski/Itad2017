using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Itad2017.Models;

namespace Itad2017.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

        }

        public DbSet<Participant> Participant { get; set; }

        public DbSet<Workshop> Workshop { get; set; }

        public DbSet<Participation> Participation { get; set; }

        public DbSet<Detail> Detail { get; set; }

        public bool SaveNewParticipant(Participant newParticipant)
        {
            
            var details = new Detail() {RegisterTime=DateTime.Now,IsConfirmed=false,IsPresent=false, Code=GenerateUniqueCode()};
            newParticipant.Details = details;
            Add(newParticipant);
            return true;
        }

        private string GenerateUniqueCode()
        {
            string kod = "";
            List<char> znaki = new List<char>() { 'A', 'B', 'C', 'E', 'D', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'R', 'S', 'T', 'U', 'W', 'Y', 'Z' };
            do
            {                                
                znaki = znaki.Select(n => n).OrderBy(n => Guid.NewGuid()).ToList();
                kod = znaki[0].ToString() + znaki[1].ToString() + znaki[2].ToString();
            } while (Detail.Select(n => n.Code).Where(n => n == kod).Count() > 0);
            return kod;
        }
    }
}
