using System.Collections.Generic;
using System.Threading.Tasks;
using Benergy.Core.Repositories;
using Benergy.Modules.Subscription.Entities;
using Benergy.Modules.Subscription.Models;

namespace Benergy.Modules.Subscription.Repositories
{
    /// <summary>
    /// Subscription DB Repository
    /// </summary>
    public class SubscriptionRepository: BaseRepository<SubscriptionDbContext>
    {
        public SubscriptionRepository(SubscriptionDbContext dbContext)
        {
            this.DbContext = dbContext;
        }
        
        #region Plan
        /// <summary>
        /// Get list of plans
        /// </summary>
        /// <returns></returns>
         public async Task<List<PlanModel>> GetPlans()
        {
            return await this.GetListAsync<PlanEntity, PlanModel>(s => s.Name);
        }

        /// <summary>
        /// Get a single Plan by ID
        /// </summary>
        /// <param name="planID"></param>
        /// <returns></returns>
        public async Task<PlanModel> GetPlan(int planID)
        {
            return await this.SingleAsync<PlanEntity, PlanModel>(p => p.ID == planID);
        }

        /// <summary>
        /// Get a single Plan by code
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public async Task<PlanModel> GetPlan(string code)
        {
            return await this.SingleAsync<PlanEntity, PlanModel>(p => p.Code == code);
        } 

        #endregion

        #region Status
        /// <summary>
        /// Get list of status
        /// </summary>
        /// <returns></returns>
         public async Task<List<StatusModel>> GetStatuses()
        {
            return await this.GetListAsync<StatusEntity, StatusModel>(s => s.Name);
        }

        /// <summary>
        /// Get a single Status by ID
        /// </summary>
        /// <param name="statusID"></param>
        /// <returns></returns>
        public async Task<StatusModel> GetStatus(int statusID)
        {
            return await this.SingleAsync<StatusEntity, StatusModel>(p => p.ID == statusID);
        }        

        /// <summary>
        /// Get a single Status by code
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public async Task<StatusModel> GetStatus(string code)
        {
            return await this.SingleAsync<StatusEntity, StatusModel>(p => p.Code == code);
        } 

        #endregion

        #region User

        /// <summary>
        /// Get list of users
        /// </summary>
        /// <returns></returns>
        public async Task<List<UserModel>> GetUsers()
        {
            return await this.GetListAsync<UserEntity, UserModel>(s => s.FullName);
        }

        /// <summary>
        /// Get user by ID
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public async Task<UserModel> GetUser(int userID)
        {
            return await this.SingleAsync<UserEntity, UserModel>(u => u.ID == userID);
        }

        /// <summary>
        /// Get user by username
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public async Task<UserModel> GetUser(string username)
        {
            return await this.SingleAsync<UserEntity, UserModel>(u => u.Username == username);
        }

        /// <summary>
        /// Add a new user 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task AddUser(UserModel model)
        {
            await this.AddEntity<UserEntity, UserModel>(model);
        }

        /// <summary>
        /// Update existing user
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task UpdateUser(UserModel model) {
            await this.UpdateEntity<UserEntity, UserModel>(model);
        }

        /// <summary>
        /// Delete user
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public async Task DeleteUser(int userID)
        {
            await this.DeleteEntity<UserEntity>(userID);
        }
        #endregion

        #region UserSubscription

        /// <summary>
        /// Get list of UserSubscriptions
        /// </summary>
        /// <returns></returns>
        public async Task<List<UserSubscriptionModel>> GetUserSubscriptions()
        {
            return await this.GetListAsync<UserSubscriptionEntity, UserSubscriptionModel>(s => s.UserID);
        }

        /// <summary>
        /// Get UserSubscription by UserID
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public async Task<List<UserSubscriptionModel>> GetUserSubscriptions(int userID)
        {
            return await this.GetListAsync<UserSubscriptionEntity, UserSubscriptionModel>(u => u.UserID == userID);
        }

        /// <summary>
        /// Get UserSubscription by ID
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public async Task<UserSubscriptionModel> GetUserSubscriptionByID(int userSubscriptionID)
        {
            return await this.SingleAsync<UserSubscriptionEntity, UserSubscriptionModel>(u => u.ID == userSubscriptionID);
        }

        /// <summary>
        /// Add a new UserSubscription 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task AddUserSubscription(UserSubscriptionModel model)
        {
            await this.AddEntity<UserSubscriptionEntity, UserSubscriptionModel>(model);
        }

        /// <summary>
        /// Update existing UserSubscription
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task UpdateUserSubscription(UserSubscriptionModel model) {
            await this.UpdateEntity<UserSubscriptionEntity, UserSubscriptionModel>(model);
        }

        /// <summary>
        /// Delete UserSubscription
        /// </summary>
        /// <param name="userSubscriptionID"></param>
        /// <returns></returns>
        public async Task DeleteUserSubscription(int userSubscriptionID)
        {
            await this.DeleteEntity<UserSubscriptionEntity>(userSubscriptionID);
        }

        #endregion
    }
}