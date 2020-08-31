using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MicrobiologyLab.Models;
using System.Linq;

namespace MicrobiologyLab.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<MicrobiologyLab.Models.Accident> Accident { get; set; }
        public DbSet<MicrobiologyLab.Models.Assesment> Assesment { get; set; }
        public DbSet<MicrobiologyLab.Models.AttendanceAssistant> AttendanceAssistant { get; set; }
        public DbSet<MicrobiologyLab.Models.AttendanceHK> AttendanceHK { get; set; }
        public DbSet<MicrobiologyLab.Models.AttendanceM2> AttendanceM2 { get; set; }
        public DbSet<MicrobiologyLab.Models.AttendancePHD> AttendancePHD { get; set; }
        public DbSet<MicrobiologyLab.Models.AttendancePHDSt> AttendancePHDSt { get; set; }
        public DbSet<MicrobiologyLab.Models.AttendanceTrainee> AttendanceTrainee { get; set; }
        public DbSet<MicrobiologyLab.Models.BacterialStock> BacterialStock { get; set; }
        public DbSet<MicrobiologyLab.Models.Biowaste> Biowaste { get; set; }
        public DbSet<MicrobiologyLab.Models.BorrowPermission> BorrowPermission { get; set; }
        public DbSet<MicrobiologyLab.Models.Collaboration> Collaboration { get; set; }
        public DbSet<MicrobiologyLab.Models.Company> Company { get; set; }
        public DbSet<MicrobiologyLab.Models.ConsumablesInventory> ConsumablesInventory { get; set; }
        public DbSet<MicrobiologyLab.Models.ConsumedMaterials> ConsumedMaterials { get; set; }
        public DbSet<MicrobiologyLab.Models.Experiment> Experiment { get; set; }
        public DbSet<MicrobiologyLab.Models.FreeForm> FreeForm { get; set; }
        public DbSet<MicrobiologyLab.Models.Freezer_20> Freezer_20 { get; set; }
        public DbSet<MicrobiologyLab.Models.Freezer_80> Freezer_80 { get; set; }
        public DbSet<MicrobiologyLab.Models.FurnituresInventory> FurnituresInventory { get; set; }
        public DbSet<MicrobiologyLab.Models.IncomingProduct> IncomingProduct { get; set; }
        public DbSet<MicrobiologyLab.Models.InternshipRequest> InternshipRequest { get; set; }
        public DbSet<MicrobiologyLab.Models.ItemsInventory> ItemsInventory { get; set; }
        public DbSet<MicrobiologyLab.Models.MachinesInventory> MachinesInventory { get; set; }
        public DbSet<MicrobiologyLab.Models.MachinesReservation> MachinesReservation { get; set; }
        public DbSet<MicrobiologyLab.Models.MachinesTC> MachinesTC { get; set; }
        public DbSet<MicrobiologyLab.Models.MeetingPresence> MeetingPresence { get; set; }
        public DbSet<MicrobiologyLab.Models.MeetingRR> MeetingRR { get; set; }
        public DbSet<MicrobiologyLab.Models.MembershipRequest> MembershipRequest { get; set; }
        public DbSet<MicrobiologyLab.Models.OpeningAndClosing> OpeningAndClosing { get; set; }
        public DbSet<MicrobiologyLab.Models.Order> Order { get; set; }
        public DbSet<MicrobiologyLab.Models.PrintingPermission> PrintingPermission { get; set; }
        public DbSet<MicrobiologyLab.Models.Project> Project { get; set; }
        public DbSet<MicrobiologyLab.Models.Project_Collaboration> Project_Collaboration { get; set; }
        public DbSet<MicrobiologyLab.Models.Project_Researcher> Project_Researcher { get; set; }
        public DbSet<MicrobiologyLab.Models.RequiredMaterial> RequiredMaterial { get; set; }
        public DbSet<MicrobiologyLab.Models.Researcher> Researcher { get; set; }
        public DbSet<MicrobiologyLab.Models.Rotation> Rotation { get; set; }
        public DbSet<MicrobiologyLab.Models.TestingAndCalibration> TestingAndCalibration { get; set; }
        public DbSet<MicrobiologyLab.Models.TrainingPreRegistration> TrainingPreRegistration { get; set; }
        public DbSet<MicrobiologyLab.Models.User> User { get; set; }
        public DbSet<MicrobiologyLab.Models.User_OpeningClosing> User_OpeningClosing { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var cascadeFKs = modelBuilder.Model.GetEntityTypes().SelectMany(t => t.GetForeignKeys())
         .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            foreach (var fk in cascadeFKs)
                fk.DeleteBehavior = DeleteBehavior.Restrict;

            base.OnModelCreating(modelBuilder);
        }
    }
}
