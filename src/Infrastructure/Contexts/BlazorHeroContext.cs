using MVWorkflows.Application.Interfaces.Services;
using MVWorkflows.Application.Models.Chat;
using MVWorkflows.Application.Models.Identity;
using MVWorkflows.Domain.Contracts;
using MVWorkflows.Domain.Entities.Catalog;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MVWorkflows.Domain.Entities.ExtendedAttributes;
using MVWorkflows.Domain.Entities.Misc;
using MVWorkflows.Application.Models.Workflows;
using MVWorkflows.Application.Models.RH;
using static MVWorkflows.Shared.Constants.Permission.Permissions;

namespace MVWorkflows.Infrastructure.Contexts
{
    public class BlazorHeroContext : AuditableContext
    {
        private readonly ICurrentUserService _currentUserService;
        private readonly IDateTimeService _dateTimeService;

        public BlazorHeroContext(DbContextOptions<BlazorHeroContext> options, ICurrentUserService currentUserService, IDateTimeService dateTimeService)
            : base(options)
        {
            _currentUserService = currentUserService;
            _dateTimeService = dateTimeService;
        }

        public DbSet<ChatHistory<BlazorHeroUser>> ChatHistories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<DocumentType> DocumentTypes { get; set; }
        public DbSet<DocumentExtendedAttribute> DocumentExtendedAttributes { get; set; }

        //RH
        public DbSet<Application.Models.RH.Profils> Profils { get; set; }
        public DbSet<Application.Models.RH.Poste> Postes { get; set; }
        public DbSet<ProfilPoste> ProfilPostes { get; set; }
        public DbSet<Application.Models.RH.TypeGroupement> TypeGroupements { get; set; }
        public DbSet<Application.Models.RH.Groupement> Groupements { get; set; }
        public DbSet<Application.Models.RH.HistoriqueAffectationPersonnel> HistoriqueAffectationPersonnels { get; set; }

        //Workflows
        public DbSet<Application.Models.Workflows.Workflows> Workflows { get; set; }
        public DbSet<Application.Models.Workflows.WorkflowInstance> WorkflowInstances { get; set; }
        public DbSet<Application.Models.Workflows.WorkflowInstanceActions> WorkflowInstanceActions { get; set; }
        public DbSet<Application.Models.Workflows.WorkflowInstanceActionData> WorkflowInstanceActionDatas { get; set; }
        public DbSet<Application.Models.Workflows.WorkflowInstanceActionFile> WorkflowInstanceActionFiles { get; set; }
        public DbSet<Application.Models.Workflows.WorkflowInstanceActionNote> WorkflowInstanceActionNotes { get; set; }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
        {
            foreach (var entry in ChangeTracker.Entries<IAuditableEntity>().ToList())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedOn = _dateTimeService.NowUtc;
                        entry.Entity.CreatedBy = _currentUserService.UserId;
                        break;

                    case EntityState.Modified:
                        entry.Entity.LastModifiedOn = _dateTimeService.NowUtc;
                        entry.Entity.LastModifiedBy = _currentUserService.UserId;
                        break;
                }
            }
            if (_currentUserService.UserId == null)
            {
                return await base.SaveChangesAsync(cancellationToken);
            }
            else
            {
                return await base.SaveChangesAsync(_currentUserService.UserId, cancellationToken);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            foreach (var property in builder.Model.GetEntityTypes()
            .SelectMany(t => t.GetProperties())
            .Where(p => p.ClrType == typeof(decimal) || p.ClrType == typeof(decimal?)))
            {
                property.SetColumnType("decimal(18,2)");
            }

            #region Schema RH

            builder.Entity<Application.Models.RH.Groupement>().ToTable("Groupement", "RH");
            builder.Entity<Application.Models.RH.HistoriqueAffectationPersonnel>().ToTable("HistoriqueAffectationPersonnel", "RH");
            builder.Entity<Application.Models.RH.Poste>().ToTable("Poste", "RH");
            builder.Entity<Application.Models.RH.ProfilPoste>().ToTable("ProfilPoste", "RH");
            builder.Entity<Application.Models.RH.Profils>().ToTable("Profils", "RH");
            builder.Entity<Application.Models.RH.TypeGroupement>().ToTable("TypeGroupement", "RH");

            #endregion

            #region Schema Workflows

            builder.Entity<Application.Models.Workflows.WorkflowInstance>().ToTable("WorkflowInstance", "Workflows");
            builder.Entity<Application.Models.Workflows.WorkflowInstanceActionData>().ToTable("WorkflowInstanceActionData", "Workflows");
            builder.Entity<Application.Models.Workflows.WorkflowInstanceActionFile>().ToTable("WorkflowInstanceActionFile", "Workflows");
            builder.Entity<Application.Models.Workflows.WorkflowInstanceActionNote>().ToTable("WorkflowInstanceActionNote", "Workflows");
            builder.Entity<Application.Models.Workflows.WorkflowInstanceActions>().ToTable("WorkflowInstanceActions", "Workflows");
            builder.Entity<Application.Models.Workflows.WorkflowInstanceStakeHolder>().ToTable("WorkflowInstanceStakeHolder", "Workflows");
            builder.Entity<Application.Models.Workflows.Workflows>().ToTable("Workflows", "Workflows");

            #endregion

            base.OnModelCreating(builder);



            builder.Entity<ChatHistory<BlazorHeroUser>>(entity =>
            {
                entity.ToTable("ChatHistory");

                entity.HasOne(d => d.FromUser)
                    .WithMany(p => p.ChatHistoryFromUsers)
                    .HasForeignKey(d => d.FromUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.ToUser)
                    .WithMany(p => p.ChatHistoryToUsers)
                    .HasForeignKey(d => d.ToUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });
            builder.Entity<BlazorHeroUser>(entity =>
            {
                entity.ToTable(name: "Users", "Identity");
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });

            builder.Entity<BlazorHeroRole>(entity =>
            {
                entity.ToTable(name: "Roles", "Identity");
            });
            builder.Entity<IdentityUserRole<string>>(entity =>
            {
                entity.ToTable("UserRoles", "Identity");
            });

            builder.Entity<IdentityUserClaim<string>>(entity =>
            {
                entity.ToTable("UserClaims", "Identity");
            });

            builder.Entity<IdentityUserLogin<string>>(entity =>
            {
                entity.ToTable("UserLogins", "Identity");
            });

            builder.Entity<BlazorHeroRoleClaim>(entity =>
            {
                entity.ToTable(name: "RoleClaims", "Identity");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.RoleClaims)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            builder.Entity<IdentityUserToken<string>>(entity =>
            {
                entity.ToTable("UserTokens", "Identity");
            });

            #region RH
            //HistoriqueAffectationPersonnel.PosteSourceId     
            //builder.Entity<Application.Models.RH.HistoriqueAffectationPersonnel>(entity => {
            //    entity.HasOne(typeof(MVWorkflows.Application.Models.RH.Poste), "PosteSource")
            //    .WithMany()
            //    .HasForeignKey("PosteSourceId")
            //    .OnDelete(DeleteBehavior.ClientSetNull); // no ON DELETE       
            //});

            builder.Entity<Application.Models.RH.HistoriqueAffectationPersonnel>(entity =>
            {
                entity.HasOne(d => d.PosteSource)
                    .WithMany()
                    .HasForeignKey("PosteSourceId")
                    .IsRequired(false)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            }); // no ON DELETE

            builder.Entity<Application.Models.RH.HistoriqueAffectationPersonnel>(entity =>
          {
              entity.HasOne(d => d.PosteDestination)
               .WithMany()
               .HasForeignKey("PosteDestinationId")
               .IsRequired(false)
               .OnDelete(DeleteBehavior.ClientSetNull);

              entity.Property(e => e.Id).ValueGeneratedOnAdd();
          }); // no ON DELETE // no ON DELETE


            //Poste.PosteSuperieurId
            builder.Entity<Application.Models.RH.Poste>(entity =>
            {
                entity.HasOne(d => d.PosteSuperieur)
               .WithMany()
               .HasForeignKey("PosteSuperieurId")
               .IsRequired(false)
               .OnDelete(DeleteBehavior.ClientSetNull);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            }); // no ON DELETE // no ON DELETE

            //Poste.IdGroupement
            builder.Entity<Application.Models.RH.Poste>(entity =>
            {
                entity.HasOne(d => d.Groupement)
               .WithMany()
               .HasForeignKey("IdGroupement")
               .IsRequired(false)
               .OnDelete(DeleteBehavior.ClientSetNull);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            }); // no ON DELETE // no ON DELETE


            //Groupement.IdTypeGroupement
            builder.Entity<Application.Models.RH.Groupement>(entity =>
            {
                entity.HasOne(d => d.TypeGroupement)
               .WithMany()
               .HasForeignKey("IdTypeGroupement")
               .IsRequired(false)
               .OnDelete(DeleteBehavior.ClientSetNull);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            }); // no ON DELETE // no ON DELETE

            ////TypeGroupement.PosteId
            //builder.Entity<ProfilPoste>(entity =>
            //{
            //    entity.HasOne(d => d.Poste)
            //   .WithMany()
            //   .HasForeignKey("PosteId")
            //   .OnDelete(DeleteBehavior.ClientSetNull);

            //    entity.Property(e => e.Id).ValueGeneratedOnAdd();
            //}); // no ON DELETE // no ON DELETE


            //ProfilPoste.ProfilId
            builder.Entity<Application.Models.RH.ProfilPoste>(entity =>
            {
                entity.HasOne(d => d.Profil)
               .WithMany()
               .HasForeignKey("ProfilId")
               .IsRequired(false)
               .OnDelete(DeleteBehavior.ClientSetNull);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            }); // no ON DELETE // no ON DELETE


            //ProfilPoste.PosteId
            builder.Entity<Application.Models.RH.ProfilPoste>(entity =>
            {
                entity.HasOne(d => d.Poste)
               .WithMany()
               .HasForeignKey("PosteId")
               .IsRequired(false)
               .OnDelete(DeleteBehavior.ClientSetNull);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            }); // no ON DELETE // no ON DELETE 
            #endregion

            #region Workflows
            //Workflows.WorkflowOwnerUserID
            builder.Entity<Application.Models.Workflows.Workflows>(entity =>
            {
                entity.HasOne(d => d.WorkflowOwnerUser)
                .WithMany()
                .HasForeignKey("WorkflowOwnerUserID")
               .IsRequired(false)
                .OnDelete(DeleteBehavior.ClientSetNull);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            }); // no ON DELETE // no ON DELETE 

            //Workflows.WorkflowOwnerUserID
            builder.Entity<Application.Models.Workflows.WorkflowInstance>(entity =>
            {
                entity.HasOne(d => d.WorkflowInstantiatorUser)
                .WithMany()
                .HasForeignKey("WorkflowInstantiatorUserId")
               .IsRequired(false)
                .OnDelete(DeleteBehavior.ClientSetNull);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            }); // no ON DELETE // no ON DELETE 


            //WorkflowInstance.WorkflowInstanceId
            builder.Entity<Application.Models.Workflows.WorkflowInstanceActions>(entity =>
            {
                entity.HasOne(d => d.WorkflowInstance)
                .WithMany()
                .HasForeignKey("WorkflowInstanceId")
               .IsRequired(false)
                .OnDelete(DeleteBehavior.ClientSetNull);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            }); // no ON DELETE // no ON DELETE 


            //WorkflowInstanceActionData.WokflowsInstanceActionId
            builder.Entity<Application.Models.Workflows.WorkflowInstanceActionData>(entity =>
            {
                entity.HasOne(d => d.WorkflowInstanceActions)
                .WithMany()
                .HasForeignKey("WokflowsInstanceActionId")
               .IsRequired(false)
                .OnDelete(DeleteBehavior.ClientSetNull);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            }); // no ON DELETE // no ON DELETE 


            //WorkflowInstanceActionFile.ActionFileRecordedByUserID
            builder.Entity<Application.Models.Workflows.WorkflowInstanceActionFile>(entity =>
            {
                entity.HasOne(d => d.ActionFileRecordedByUser)
                .WithMany()
                .HasForeignKey("ActionFileRecordedByUserID")
               .IsRequired(false)
                .OnDelete(DeleteBehavior.ClientSetNull);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            }); // no ON DELETE // no ON DELETE 

            //WorkflowInstanceActionNote.ActionNoteTakedByUserID
            builder.Entity<Application.Models.Workflows.WorkflowInstanceActionNote>(entity =>
        {
            entity.HasOne(d => d.ActionNoteTakedByUser)
                .WithMany()
                .HasForeignKey("ActionNoteTakedByUserID")
               .IsRequired(false)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
        }); // no ON DELETE // no ON DELETE 

            //WorkflowInstanceStakeHolder.StakeHolderUserID
            builder.Entity<Application.Models.Workflows.WorkflowInstanceStakeHolder>(entity =>
        {
            entity.HasOne(d => d.StakeHolderUser)
        .WithMany()
        .HasForeignKey("StakeHolderUserID")
               .IsRequired(false)
        .OnDelete(DeleteBehavior.ClientSetNull);

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
        }); // no ON DELETE // no ON DELETE 

            #endregion
        }
    }
}