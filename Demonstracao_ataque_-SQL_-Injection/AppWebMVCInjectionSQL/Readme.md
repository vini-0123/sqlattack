Cada pacote � licenciado para voc� por seu propriet�rio. A NuGet n�o � respons�vel por pacotes de terceiros nem concede licen�as a eles. Alguns pacotes podem incluir depend�ncias que s�o administradas por licen�as adicionais. Siga a URL da origem (feed) do pacote para determinar todas as depend�ncias.

Vers�o 6.11.1.2 do Host do Console do Gerenciador de Pacotes

Digite 'get-help NuGet' para ver todos os comandos dispon�veis do NuGet.

PM> dotnet ef migration add Inicial
No project was found. Change the current working directory or use the --project option.
PM> dotnet ef migrations add Inicial
No project was found. Change the current working directory or use the --project option.
PM> add-migration Inicial
Build started...
Build succeeded.
To undo this action, use Remove-Migration.
PM> update-database
Build started...
Build succeeded.
Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (246ms) [Parameters=[], CommandType='Text', CommandTimeout='60']
      CREATE DATABASE [SQLInjectionDemo];
Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (106ms) [Parameters=[], CommandType='Text', CommandTimeout='60']
      IF SERVERPROPERTY('EngineEdition') <> 5
      BEGIN
          ALTER DATABASE [SQLInjectionDemo] SET READ_COMMITTED_SNAPSHOT ON;
      END;
Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (10ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      SELECT 1
Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (16ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      CREATE TABLE [__EFMigrationsHistory] (
          [MigrationId] nvarchar(150) NOT NULL,
          [ProductVersion] nvarchar(32) NOT NULL,
          CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
      );
Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (0ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      SELECT 1
Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (16ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      SELECT OBJECT_ID(N'[__EFMigrationsHistory]');
Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (12ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      SELECT [MigrationId], [ProductVersion]
      FROM [__EFMigrationsHistory]
      ORDER BY [MigrationId];
Microsoft.EntityFrameworkCore.Migrations[20402]
      Applying migration '00000000000000_CreateIdentitySchema'.
Applying migration '00000000000000_CreateIdentitySchema'.
Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (4ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      CREATE TABLE [AspNetRoles] (
          [Id] nvarchar(450) NOT NULL,
          [Name] nvarchar(256) NULL,
          [NormalizedName] nvarchar(256) NULL,
          [ConcurrencyStamp] nvarchar(max) NULL,
          CONSTRAINT [PK_AspNetRoles] PRIMARY KEY ([Id])
      );
Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (3ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      CREATE TABLE [AspNetUsers] (
          [Id] nvarchar(450) NOT NULL,
          [UserName] nvarchar(256) NULL,
          [NormalizedUserName] nvarchar(256) NULL,
          [Email] nvarchar(256) NULL,
          [NormalizedEmail] nvarchar(256) NULL,
          [EmailConfirmed] bit NOT NULL,
          [PasswordHash] nvarchar(max) NULL,
          [SecurityStamp] nvarchar(max) NULL,
          [ConcurrencyStamp] nvarchar(max) NULL,
          [PhoneNumber] nvarchar(max) NULL,
          [PhoneNumberConfirmed] bit NOT NULL,
          [TwoFactorEnabled] bit NOT NULL,
          [LockoutEnd] datetimeoffset NULL,
          [LockoutEnabled] bit NOT NULL,
          [AccessFailedCount] int NOT NULL,
          CONSTRAINT [PK_AspNetUsers] PRIMARY KEY ([Id])
      );
Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (4ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      CREATE TABLE [AspNetRoleClaims] (
          [Id] int NOT NULL IDENTITY,
          [RoleId] nvarchar(450) NOT NULL,
          [ClaimType] nvarchar(max) NULL,
          [ClaimValue] nvarchar(max) NULL,
          CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY ([Id]),
          CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE
      );
Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (3ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      CREATE TABLE [AspNetUserClaims] (
          [Id] int NOT NULL IDENTITY,
          [UserId] nvarchar(450) NOT NULL,
          [ClaimType] nvarchar(max) NULL,
          [ClaimValue] nvarchar(max) NULL,
          CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY ([Id]),
          CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
      );
Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (3ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      CREATE TABLE [AspNetUserLogins] (
          [LoginProvider] nvarchar(128) NOT NULL,
          [ProviderKey] nvarchar(128) NOT NULL,
          [ProviderDisplayName] nvarchar(max) NULL,
          [UserId] nvarchar(450) NOT NULL,
          CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY ([LoginProvider], [ProviderKey]),
          CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
      );
Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (7ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      CREATE TABLE [AspNetUserRoles] (
          [UserId] nvarchar(450) NOT NULL,
          [RoleId] nvarchar(450) NOT NULL,
          CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY ([UserId], [RoleId]),
          CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE,
          CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
      );
Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (3ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      CREATE TABLE [AspNetUserTokens] (
          [UserId] nvarchar(450) NOT NULL,
          [LoginProvider] nvarchar(128) NOT NULL,
          [Name] nvarchar(128) NOT NULL,
          [Value] nvarchar(max) NULL,
          CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY ([UserId], [LoginProvider], [Name]),
          CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
      );
Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (6ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      CREATE INDEX [IX_AspNetRoleClaims_RoleId] ON [AspNetRoleClaims] ([RoleId]);
Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (4ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      CREATE UNIQUE INDEX [RoleNameIndex] ON [AspNetRoles] ([NormalizedName]) WHERE [NormalizedName] IS NOT NULL;
Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (3ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      CREATE INDEX [IX_AspNetUserClaims_UserId] ON [AspNetUserClaims] ([UserId]);
Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (2ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      CREATE INDEX [IX_AspNetUserLogins_UserId] ON [AspNetUserLogins] ([UserId]);
Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (1ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      CREATE INDEX [IX_AspNetUserRoles_RoleId] ON [AspNetUserRoles] ([RoleId]);
Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (2ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      CREATE INDEX [EmailIndex] ON [AspNetUsers] ([NormalizedEmail]);
Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (2ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      CREATE UNIQUE INDEX [UserNameIndex] ON [AspNetUsers] ([NormalizedUserName]) WHERE [NormalizedUserName] IS NOT NULL;
Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (12ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
      VALUES (N'00000000000000_CreateIdentitySchema', N'8.0.10');
Microsoft.EntityFrameworkCore.Migrations[20402]
      Applying migration '20241020131252_Inicial'.
Applying migration '20241020131252_Inicial'.
Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (2ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      CREATE TABLE [Alunos] (
          [Id] int NOT NULL IDENTITY,
          [Nome] nvarchar(max) NULL,
          [Idade] int NOT NULL,
          CONSTRAINT [PK_Alunos] PRIMARY KEY ([Id])
      );
Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (2ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      CREATE TABLE [Professores] (
          [Id] int NOT NULL IDENTITY,
          [Nome] nvarchar(max) NULL,
          [Disciplina] nvarchar(max) NULL,
          CONSTRAINT [PK_Professores] PRIMARY KEY ([Id])
      );
Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (5ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
      VALUES (N'20241020131252_Inicial', N'8.0.10');
Done.
PM> 