// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Oracle.EntityFrameworkCore.Metadata;
using Orchard.Repository;

namespace Orchard.Repository.Migrations
{
    [DbContext(typeof(OrchardContext))]
    partial class OrchardContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn)
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("Relational:Sequence:.HARVEST_SEQ", "'HARVEST_SEQ', '', '1', '1', '', '', 'Int32', 'False'")
                .HasAnnotation("Relational:Sequence:.SPECIE_SEQ", "'SPECIE_SEQ', '', '1', '1', '', '', 'Int32', 'False'")
                .HasAnnotation("Relational:Sequence:.TREE_SEQ", "'TREE_SEQ', '', '1', '1', '', '', 'Int32', 'False'")
                .HasAnnotation("Relational:Sequence:.TREEGROUP_SEQ", "'TREEGROUP_SEQ', '', '1', '1', '', '', 'Int32', 'False'");

            modelBuilder.Entity("Orchard.Domain.Harvest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("NUMBER(10)")
                        .HasAnnotation("Oracle:HiLoSequenceName", "HARVEST_SEQ")
                        .HasAnnotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.SequenceHiLo);

                    b.Property<DateTime>("Date")
                        .HasColumnName("Date")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<decimal>("GrossWeight")
                        .HasColumnName("GrossWeight")
                        .HasColumnType("DECIMAL(18, 2)");

                    b.Property<string>("Information")
                        .HasColumnName("Information")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<int>("TreeId")
                        .HasColumnName("TreeId")
                        .HasColumnType("NUMBER(10)");

                    b.HasKey("Id");

                    b.HasIndex("TreeId");

                    b.ToTable("Harvests");
                });

            modelBuilder.Entity("Orchard.Domain.Specie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("NUMBER(10)")
                        .HasAnnotation("Oracle:HiLoSequenceName", "SPECIE_SEQ")
                        .HasAnnotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.SequenceHiLo);

                    b.Property<string>("Description")
                        .HasColumnName("Description")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("Id");

                    b.ToTable("Species");
                });

            modelBuilder.Entity("Orchard.Domain.Tree", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("NUMBER(10)")
                        .HasAnnotation("Oracle:HiLoSequenceName", "TREE_SEQ")
                        .HasAnnotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.SequenceHiLo);

                    b.Property<int>("Age")
                        .HasColumnName("Age")
                        .HasColumnType("NUMBER(10)");

                    b.Property<string>("Description")
                        .HasColumnName("Description")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<int>("SpecieId")
                        .HasColumnName("SpecieId")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int?>("TreeGroupId")
                        .HasColumnType("NUMBER(10)");

                    b.HasKey("Id");

                    b.HasIndex("SpecieId");

                    b.HasIndex("TreeGroupId");

                    b.ToTable("Trees");
                });

            modelBuilder.Entity("Orchard.Domain.TreeGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("NUMBER(10)")
                        .HasAnnotation("Oracle:HiLoSequenceName", "TREEGROUP_SEQ")
                        .HasAnnotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.SequenceHiLo);

                    b.Property<string>("Description")
                        .HasColumnName("Description")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("Name")
                        .HasColumnName("Name")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<int>("TreeId")
                        .HasColumnName("TreeId")
                        .HasColumnType("NUMBER(10)");

                    b.HasKey("Id");

                    b.ToTable("TreeGroups");
                });

            modelBuilder.Entity("Orchard.Domain.Harvest", b =>
                {
                    b.HasOne("Orchard.Domain.Tree", "Tree")
                        .WithMany()
                        .HasForeignKey("TreeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Orchard.Domain.Tree", b =>
                {
                    b.HasOne("Orchard.Domain.Specie", "Specie")
                        .WithMany()
                        .HasForeignKey("SpecieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Orchard.Domain.TreeGroup", null)
                        .WithMany("Trees")
                        .HasForeignKey("TreeGroupId");
                });
#pragma warning restore 612, 618
        }
    }
}
