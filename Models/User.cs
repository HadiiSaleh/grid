using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicrobiologyLab.Models
{
    public enum Role
    {
        admin, phd, phdStudent, m2, trainee, assistant
    }

    public class User
    {


        public int UserId { get; set; }

        public string email { get; set; }
        public string password { get; set; }
        public Role? role { get; set; }


        //attendances
        public virtual ICollection<AttendanceAssistant> AssistanceAttendances { get; set; }
        public virtual ICollection<AttendanceHK> HKAttendances { get; set; }
        public virtual ICollection<AttendanceM2> M2Attendances { get; set; }
        public virtual ICollection<AttendancePHD> PHDAttendances { get; set; }
        public virtual ICollection<AttendancePHDSt> PHDStAttendances { get; set; }
        public virtual ICollection<AttendanceTrainee> TraineeAttendances { get; set; }

        //forms
        public virtual ICollection<Assesment> Assesments { get; set; }
        public virtual ICollection<InternshipRequest> InternshipRequests { get; set; }
        public virtual ICollection<PrintingPermission> PrintingPermissions { get; set; }
        public virtual ICollection<BorrowPermission> BorrowPermissions { get; set; }
        public virtual ICollection<TrainingPreRegistration> TrainingPreRegistrations { get; set; }
        public virtual ICollection<FreeForm> FreeForms { get; set; }
        public virtual ICollection<WorkPermission> WorkPermissions { get; set; }
        public virtual ICollection<MembershipRequest> MembershipRequests { get; set; }

        public virtual ICollection<IncomingProduct> IncomingProducts { get; set; }
        public virtual ICollection<Company> Companies { get; set; }
        public virtual ICollection<Order> Orders { get; set; }

        public virtual ICollection<Collaboration> Collaborations { get; set; }
        public virtual ICollection<Project> Projects { get; set; }

        public virtual ICollection<TestingAndCalibration> TestingAndCalibrations { get; set; }
        public virtual ICollection<MeetingRR> MeetingRoomReservations { get; set; }
        public virtual ICollection<Accident> Accidents { get; set; }

        public virtual ICollection<Rotation> Rotations { get; set; }

        public virtual ICollection<User_OpeningClosing> User_OpeningClosings { get; set; }

        public virtual ICollection<ConsumablesInventory> Consumables { get; set; }
        public virtual ICollection<FurnituresInventory> Furnitures { get; set; }
        public virtual ICollection<ItemsInventory> Items { get; set; }
        public virtual ICollection<MachinesInventory> Machines { get; set; }
    }
}
