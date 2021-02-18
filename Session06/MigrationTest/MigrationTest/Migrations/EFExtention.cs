using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.EntityFrameworkCore.Migrations.Operations.Builders;
using System.Diagnostics.CodeAnalysis;

namespace MigrationTest.Migrations
{
    public class CreateUserOperation : MigrationOperation
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }



    public static class EFExtention
    {
        public static OperationBuilder<SqlOperation> CreateUser(this MigrationBuilder builder, string userName, string passwor)
        {
            return builder.Sql("Create User ");
        }


        public static OperationBuilder<CreateUserOperation> CreateUser2(this MigrationBuilder builder, string userName, string password)
        {
            var operation = new CreateUserOperation
            {
                UserName = userName,
                Password = password
            };
            builder.Operations.Add(operation);
            return new OperationBuilder<CreateUserOperation>(operation);
        }
    }

    public class GolrangSqlMigrationGenerator : SqlServerMigrationsSqlGenerator
    {
        public GolrangSqlMigrationGenerator([NotNullAttribute] MigrationsSqlGeneratorDependencies dependencies, [NotNullAttribute] IRelationalAnnotationProvider migrationsAnnotations) : base(dependencies, migrationsAnnotations)
        {
        }

        protected override void Generate(MigrationOperation operation, IModel model, MigrationCommandListBuilder builder)
        {
            if (operation is CreateUserOperation createUserOperation)
            {

            }
            else
            {
                base.Generate(operation, model, builder);
            }
        }
    }
}
