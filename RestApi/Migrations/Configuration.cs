using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using RestApi.Models;

namespace RestApi.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<RestApi.DataAccess.DomainDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(RestApi.DataAccess.DomainDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "Admin" };

                manager.Create(role);
            }

            if (!context.Users.Any(u => u.UserName == "admin@teste.com"))
            {
                var store = new UserStore<Usuario>(context);
                var manager = new UserManager<Usuario>(store);
                var user = new Usuario { UserName = "admin@teste.com", Email = "admin@teste.com", Nome = "AdminNome", Sobrenome = "AdminSobrenome"};

                manager.Create(user, "Teste.123");
                manager.AddToRole(user.Id, "Admin");
            }

            context.Produtos.AddOrUpdate(produto => produto.Nome,
                new Produto() {Nome = "Game - Final Fantasy XV: Edição Limitada - PS4", Preco = 231.23m},
                new Produto() {Nome = "Game Battlefield 1 - PS4", Preco = 199.00m },
                new Produto() {Nome = "Game FIFA 17 - PS4", Preco = 199.90m},
                new Produto() {Nome = "Game - Grand Theft Auto V - PS4", Preco = 149.99m },
                new Produto() {Nome = "Game Watch Dogs 2 - PS4", Preco = 198.99m },
                new Produto() {Nome = "Game - Forza Horizon 3 - Xbox One", Preco = 99.99m },
                new Produto() {Nome = "Game Overwatch: Edição Origins - PS4", Preco = 199.99m },
                new Produto() {Nome = "Game - The Witcher 3: Wild Hunt - PS4", Preco = 79.99m },
                new Produto() {Nome = "Game Grand Theft Auto V  -  Xbox One", Preco = 149.99m},
                new Produto() {Nome = "Game - Pro Evolution Soccer 2017 - PS4", Preco = 119.99m },
                new Produto() {Nome = "Game - Gears Of War 4 - Xbox One", Preco = 89.90m },
                new Produto() {Nome = "Game - Fallout 4 - PS4", Preco = 49.90m },
                new Produto() {Nome = "Game Battlefield 1 - Xbox One", Preco = 170.00m },
                new Produto() {Nome = "Game - Bloodborne - PS4", Preco = 79.90m },
                new Produto() {Nome = "Game Until Dawn - PS4", Preco = 79.99m },
                new Produto() {Nome = "Game - Uncharted The Nathan Drake Collection - PS4", Preco = 79.90m },
                new Produto() {Nome = "Game Call Of Duty: Black Ops 3 Gold Edition - PS4", Preco = 99.99m },
                new Produto() {Nome = "Game Rise Of The Tomb Raider - PS4", Preco = 168.99m },
                new Produto() {Nome = "Game - Batman: Arkham Knight - PS4", Preco = 99.99m },
                new Produto() {Nome = "Game Fallout 4 - Xbox One", Preco = 49.90m }
            );
        }
    }
}
