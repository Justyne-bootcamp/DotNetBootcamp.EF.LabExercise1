using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using WorkScheduleSolution.Entities;

namespace WorkScheduleSolution.Data
{
    public class WorkScheduleContext: DbContext
    {
        public DbSet<Location> Locations { get; set; }
        public DbSet<PlacementContract> PlacementContracts { get; set; }
        public DbSet<Shift> Shifts { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<EmployeeSkill> EmployeeSkills { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=JLMBQG3;Database=WorkSchedule;User Id=sa;Password=sqlmalambing");
            }
        }
    }
}
