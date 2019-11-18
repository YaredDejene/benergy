using System;
using Benergy.Test;
using AutoMapper;
using Benergy.Modules.Subscription.Mapping;
using Benergy.Modules.Subscription.Repositories;
using Benergy.Modules.Subscription.Domain;
using Benergy.API.Controllers;
using Xunit;
using Benergy.Modules.Subscription.Entities;
using Benergy.Modules.Subscription.Models;
using System.Collections.Generic;
using Benergy.Core.Models.API;
using Benergy.Modules.Subscription.Common;
using System.Linq;

namespace Benergy.Modules.Subscription.Test
{
    public class SubscriptionControllerTest: BaseTest
    {
        #region Constructor and Initialization
        public SubscriptionControllerTest()
        {
            this.CreateAppContext();

            // Automapper initializers
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<SubscriptionProfileMapping>();
            });

            // setting up the context and repositories
            this.SubscriptionDbContext = this.CreateDbContext<SubscriptionDbContext>();
            SubscriptionRepository subscriptionRepository = new SubscriptionRepository(this.SubscriptionDbContext);
            SubscriptionDomain subscriptionDomain = new SubscriptionDomain(subscriptionRepository);

            this.Controller = new SubscriptionController(subscriptionDomain);
        }

        protected SubscriptionDbContext SubscriptionDbContext { get; set; }

        protected SubscriptionController Controller { get; set; }

        #endregion
    
        #region User
        [Fact]
        public async void GetUsers()
        {
            // Arrange
            this.SubscriptionDbContext.Users.AddRange(
                    new UserEntity() { ID = 1, FirstName = "Yared", LastName="Dejene", Email = "yareddej@gmail.com", Role="Administrator",Password="Pass", IsDeleted = false },
                     new UserEntity() { ID = 2, FirstName = "Tadese", LastName="Tesfu", Email = "ts@gmail.com", Role="Superadmin",Password="Pass", IsDeleted = false });

            await this.SaveChangesAsync(this.SubscriptionDbContext);

            // Act
            APIResponseModel<List<UserModel>> userModel = await this.Controller.GetUsers();
            List<UserModel> users = userModel.Model;

            // Assert
            Assert.Equal(users.Count, 2);
            Assert.Equal(users[0].FirstName, "Tadese");
        }

        [Fact]
        public async void GetUser()
        {
            // Arrange
            this.SubscriptionDbContext.Users.AddRange(
                    new UserEntity() { ID = 1, FirstName = "Yared", LastName="Dejene", Email = "yareddej@gmail.com", Role="Administrator",Password="Pass", IsDeleted = false },
                     new UserEntity() { ID = 2, FirstName = "Tadese", LastName="Tesfu", Email = "ts@gmail.com", Role="Superadmin",Password="Pass", IsDeleted = false });

            await this.SaveChangesAsync(this.SubscriptionDbContext);

            // Act
            APIResponseModel<UserModel> userModel = await this.Controller.GetUser(1);
            UserModel user = userModel.Model;

            // Assert
            Assert.Equal(user.FirstName, "Yared");
        }

        [Fact]
        public async void AddUser()
        {
            // Arrange
            UserModel model = new UserModel() { FirstName = "Yared", LastName="Dejene", Email = "yareddej@gmail.com", Role="Administrator",Password="Pass" };

            // Act
            APIResponseModel<NTModel> ntModel = await this.Controller.AddUser(model);

            // Assert
            UserEntity entity = this.SubscriptionDbContext.Users.Last();
            Assert.Equal(entity.FirstName, "Yared");
            Assert.Equal(ntModel.Message, SubscriptionMessages.UserAddedSuccess);
        }

        [Fact]
        public async void UpdateUser()
        {
            // Arrange
            this.SubscriptionDbContext.Users.AddRange(
                    new UserEntity() { ID = 1, FirstName = "Yared", LastName="Dejene", Email = "yareddej@gmail.com", Role="Administrator",Password="Pass", IsDeleted = false },
                     new UserEntity() { ID = 2, FirstName = "Tadese", LastName="Tesfu", Email = "ts@gmail.com", Role="Superadmin",Password="Pass", IsDeleted = false });

            await this.SaveChangesAsync(this.SubscriptionDbContext);

            UserModel model = new UserModel() { ID = 2, FirstName = "Tadese", LastName="Taye" };

            // Act
            APIResponseModel<NTModel> ntModel = await this.Controller.UpdateUser(model);

            // Assert
            UserEntity entity = this.SubscriptionDbContext.Users.Where(e => e.ID == 2).First();
            Assert.Equal(entity.FirstName, "Tadese");
            Assert.Equal(ntModel.Message, SubscriptionMessages.UserUpdatedSuccess);
        }

        [Fact]
        public async void DeleteUser()
        {
            // Arrange
            this.SubscriptionDbContext.Users.AddRange(
                    new UserEntity() { ID = 1, FirstName = "Yared", LastName="Dejene", Email = "yareddej@gmail.com", Role="Administrator",Password="Pass", IsDeleted = false },
                     new UserEntity() { ID = 2, FirstName = "Tadese", LastName="Tesfu", Email = "ts@gmail.com", Role="Superadmin",Password="Pass", IsDeleted = false });

            await this.SaveChangesAsync(this.SubscriptionDbContext);

            // Act
            APIResponseModel<NTModel> ntModel = await this.Controller.DeleteUser(2);

            // Assert
            UserEntity entity = this.SubscriptionDbContext.Users.Single(e => e.ID == 2);
            Assert.Equal(entity.IsDeleted, true);
            Assert.Equal(ntModel.Message, SubscriptionMessages.UserDeleteSuccess);
        }

        #endregion
    }
}
