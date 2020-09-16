using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BugTracker.Data
{
    public partial class BugTrackerDBContext : DbContext
    {
        public BugTrackerDBContext()
        {
        }

        public BugTrackerDBContext(DbContextOptions<BugTrackerDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Attachment> Attachment { get; set; }
        public virtual DbSet<Bug> Bug { get; set; }
        public virtual DbSet<Buglog> Buglog { get; set; }
        public virtual DbSet<Comment> Comment { get; set; }
        public virtual DbSet<Element> Element { get; set; }
        public virtual DbSet<Lookup> Lookup { get; set; }
        public virtual DbSet<Lookuptype> Lookuptype { get; set; }
        public virtual DbSet<Passwordrequest> Passwordrequest { get; set; }
        public virtual DbSet<Permission> Permission { get; set; }
        public virtual DbSet<Project> Project { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<Table> Table { get; set; }
        public virtual DbSet<Task> Task { get; set; }
        public virtual DbSet<Tasklog> Tasklog { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Userproject> Userproject { get; set; }
        public virtual DbSet<Userrole> Userrole { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Attachment>(entity =>
            {
                entity.ToTable("ATTACHMENT");

                entity.Property(e => e.AttachmentId).HasColumnName("AttachmentID");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.EditDate).HasColumnType("datetime");

                entity.Property(e => e.FileName)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.FilePath)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.RelatedId).HasColumnName("RelatedID");

                entity.Property(e => e.RelatedTableId).HasColumnName("RelatedTableID");

                entity.HasOne(d => d.RelatedTable)
                    .WithMany(p => p.Attachment)
                    .HasForeignKey(d => d.RelatedTableId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ATTACHMENT_TABLE");
            });

            modelBuilder.Entity<Bug>(entity =>
            {
                entity.ToTable("BUG");

                entity.Property(e => e.BugId).HasColumnName("BugID");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.EditDate).HasColumnType("datetime");

                entity.Property(e => e.IdentifiedDate).HasColumnType("datetime");

                entity.Property(e => e.StatusId).HasColumnName("StatusID");

                entity.Property(e => e.TaskId).HasColumnName("TaskID");

                entity.HasOne(d => d.StatusNavigation)
                    .WithMany(p => p.Bug)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BUG_STATUS");

                entity.HasOne(d => d.Task)
                    .WithMany(p => p.Bug)
                    .HasForeignKey(d => d.TaskId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BUG_TASK");
            });

            modelBuilder.Entity<Buglog>(entity =>
            {
                entity.ToTable("BUGLOG");

                entity.Property(e => e.BugLogId).HasColumnName("BugLogID");

                entity.Property(e => e.BugId).HasColumnName("BugID");

                entity.Property(e => e.ColumnName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EditDate).HasColumnType("datetime");

                entity.Property(e => e.NewValue)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.PreviousValue)
                    .IsRequired()
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.ToTable("COMMENT");

                entity.Property(e => e.CommentId).HasColumnName("CommentID");

                entity.Property(e => e.CommentText)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.EditDate).HasColumnType("datetime");

                entity.Property(e => e.RelatedId).HasColumnName("RelatedID");

                entity.Property(e => e.RelatedTableId).HasColumnName("RelatedTableID");

                entity.HasOne(d => d.RelatedTable)
                    .WithMany(p => p.Comment)
                    .HasForeignKey(d => d.RelatedTableId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_COMMENT_TABLE");
            });

            modelBuilder.Entity<Element>(entity =>
            {
                entity.ToTable("ELEMENT");

                entity.Property(e => e.ElementId).HasColumnName("ElementID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Lookup>(entity =>
            {
                entity.ToTable("LOOKUP");

                entity.Property(e => e.LookUpId)
                    .HasColumnName("LookUpID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LookUpTypeId).HasColumnName("LookUpTypeID");

                entity.HasOne(d => d.LookUpType)
                    .WithMany(p => p.Lookup)
                    .HasForeignKey(d => d.LookUpTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LOOKUP_LOOKUPTYPE");
            });

            modelBuilder.Entity<Lookuptype>(entity =>
            {
                entity.ToTable("LOOKUPTYPE");

                entity.Property(e => e.LookUpTypeId)
                    .HasColumnName("LookUpTypeID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Passwordrequest>(entity =>
            {
                entity.ToTable("PASSWORDREQUEST");

                entity.Property(e => e.PasswordRequestId).HasColumnName("PasswordRequestID");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.EditDate).HasColumnType("datetime");

                entity.Property(e => e.Token)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Passwordrequest)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PASSWORDREQUEST_USER");
            });

            modelBuilder.Entity<Permission>(entity =>
            {
                entity.ToTable("PERMISSION");

                entity.Property(e => e.PermissionId).HasColumnName("PermissionID");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.EditDate).HasColumnType("datetime");

                entity.Property(e => e.ElementId).HasColumnName("ElementID");

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.HasOne(d => d.Element)
                    .WithMany(p => p.Permission)
                    .HasForeignKey(d => d.ElementId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PERMISSION_ELEMENT");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Permission)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PERMISSION_ROLE");
            });

            modelBuilder.Entity<Project>(entity =>
            {
                entity.ToTable("PROJECT");

                entity.Property(e => e.ProjectId).HasColumnName("ProjectID");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.EditDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StatusId).HasColumnName("StatusID");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Project)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PROJECT_STATUS");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("ROLE");

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.EditDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.ToTable("STATUS");

                entity.Property(e => e.StatusId).HasColumnName("StatusID");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.RelatedTableId).HasColumnName("RelatedTableID");

                entity.HasOne(d => d.RelatedTable)
                    .WithMany(p => p.Status)
                    .HasForeignKey(d => d.RelatedTableId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_STATUS_TABLE");
            });

            modelBuilder.Entity<Table>(entity =>
            {
                entity.ToTable("TABLE");

                entity.Property(e => e.TableId).HasColumnName("TableID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Task>(entity =>
            {
                entity.ToTable("TASK");

                entity.Property(e => e.TaskId).HasColumnName("TaskID");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.EditDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProjectId).HasColumnName("ProjectID");

                entity.Property(e => e.StatusId).HasColumnName("StatusID");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.Task)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TASK_PROJECT");

                entity.HasOne(d => d.StatusNavigation)
                    .WithMany(p => p.Task)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TASK_STATUS");
            });

            modelBuilder.Entity<Tasklog>(entity =>
            {
                entity.ToTable("TASKLOG");

                entity.Property(e => e.TaskLogId).HasColumnName("TaskLogID");

                entity.Property(e => e.ColumnName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EditDate).HasColumnType("datetime");

                entity.Property(e => e.NewValue)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.PreviousValue)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.TaskRecordId).HasColumnName("TaskRecordID");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("USER");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.EditDate).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.StatusId).HasColumnName("StatusID");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_USER_STATUS");
            });

            modelBuilder.Entity<Userproject>(entity =>
            {
                entity.HasKey(e => new { e.ProjectId, e.UserId });

                entity.ToTable("USERPROJECT");

                entity.Property(e => e.ProjectId).HasColumnName("ProjectID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.EditDate).HasColumnType("datetime");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.Userproject)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_USERPROJECT_PROJECT");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Userproject)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_USERPROJECT_USER");
            });

            modelBuilder.Entity<Userrole>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId })
                    .HasName("USERROLE_PK");

                entity.ToTable("USERROLE");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.EditDate).HasColumnType("datetime");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Userrole)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_USERROLE_ROLE");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Userrole)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_USERROLE_USER");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
