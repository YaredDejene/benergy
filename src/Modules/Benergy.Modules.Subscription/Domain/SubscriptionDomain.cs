using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Benergy.Core.Helpers;
using Benergy.Modules.Subscription.Common;
using Benergy.Modules.Subscription.Entities;
using Benergy.Modules.Subscription.Models;
using Benergy.Modules.Subscription.Repositories;

namespace Benergy.Modules.Subscription.Domain
{
    public class SubscriptionDomain
    {
        /// <summary>
        /// Business login related with Subscription
        /// </summary>
        private SubscriptionRepository _subscriptionRepository;

        public SubscriptionDomain(SubscriptionRepository subscriptionRepository)
        {
            _subscriptionRepository = subscriptionRepository;
        }

        #region Plan
        /// <summary>
        /// Get list of plans
        /// </summary>
        /// <returns></returns>
        public async Task<List<PlanModel>> GetPlans()
        {
            return await _subscriptionRepository.GetPlans();
        }

        /// <summary>
        /// Get a single Plan by ID
        /// </summary>
        /// <param name="planID"></param>
        /// <returns></returns>
        public async Task<PlanModel> GetPlan(int planID)
        {
            return await _subscriptionRepository.GetPlan(planID);
        }

        /// <summary>
        /// Get a single Plan by code
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public async Task<PlanModel> GetPlan(string code)
        {
            return await _subscriptionRepository.GetPlan(code);
        }

        #endregion

        #region Status
        /// <summary>
        /// Get list of status
        /// </summary>
        /// <returns></returns>
        public async Task<List<StatusModel>> GetStatuses()
        {
            return await _subscriptionRepository.GetStatuses();
        }

        /// <summary>
        /// Get a single Status by ID
        /// </summary>
        /// <param name="statusID"></param>
        /// <returns></returns>
        public async Task<StatusModel> GetStatus(int statusID)
        {
            return await _subscriptionRepository.GetStatus(statusID);
        }

        /// <summary>
        /// Get a single Status by code
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public async Task<StatusModel> GetStatus(string code)
        {
            return await _subscriptionRepository.GetStatus(code);
        }

        #endregion

        #region User

        /// <summary>
        /// Get list of users
        /// </summary>
        /// <returns></returns>
        public async Task<List<UserModel>> GetUsers()
        {
            return await _subscriptionRepository.GetUsers();
        }

        /// <summary>
        /// Get user by ID
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public async Task<UserModel> GetUser(int userID)
        {
            return await _subscriptionRepository.GetUser(userID);
        }

        /// <summary>
        /// Get user by username
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public async Task<UserModel> GetUser(string username)
        {
            return await _subscriptionRepository.GetUser(username);
        }

        /// <summary>
        /// Add a new user 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task AddUser(UserModel model)
        {
            model.Password = HashHelper.HashPassword(model.Password);
            await _subscriptionRepository.AddUser(model);
            //Send email
            await SendEmailOnSignup(model);
        }

        /// <summary>
        /// Update existing user
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task UpdateUser(UserModel model)
        {

            await _subscriptionRepository.UpdateUser(model);
        }

        /// <summary>
        /// Update password
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task UpdateUserPassword(UserModel model)
        {
            model.Password = HashHelper.HashPassword(model.Password);
            await _subscriptionRepository.UpdateUser(model);
        }

        /// <summary>
        /// Delete user
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public async Task DeleteUser(int userID)
        {
            await _subscriptionRepository.DeleteUser(userID);
        }
        #endregion

        #region UserSubscription

        /// <summary>
        /// Get list of UserSubscriptions
        /// </summary>
        /// <returns></returns>
        public async Task<List<UserSubscriptionModel>> GetUserSubscriptions()
        {
            return await _subscriptionRepository.GetUserSubscriptions();
        }

        /// <summary>
        /// Get UserSubscription by UserID
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public async Task<List<UserSubscriptionModel>> GetUserSubscription(int userID)
        {
            return await _subscriptionRepository.GetUserSubscriptions(userID);
        }

        /// <summary>
        /// Get UserSubscription by ID
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public async Task<UserSubscriptionModel> GetUserSubscriptionByID(int userSubscriptionID)
        {
            return await _subscriptionRepository.GetUserSubscriptionByID(userSubscriptionID);
        }

        /// <summary>
        /// Add a new UserSubscription 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task AddUserSubscription(UserSubscriptionModel model)
        {
            await _subscriptionRepository.AddUserSubscription(model);
        }

        /// <summary>
        /// Update existing UserSubscription
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task UpdateUserSubscription(UserSubscriptionModel model)
        {
            await _subscriptionRepository.UpdateUserSubscription(model);
        }

        /// <summary>
        /// Delete UserSubscription
        /// </summary>
        /// <param name="userSubscriptionID"></param>
        /// <returns></returns>
        public async Task DeleteUserSubscription(int userSubscriptionID)
        {
            await _subscriptionRepository.DeleteUserSubscription(userSubscriptionID);
        }

        /// <summary>
        /// Deactivate UserSubscription
        /// </summary>
        /// <param name="userSubscriptionID"></param>
        /// <returns></returns>
        public async Task DeactivateUserSubscription(UserSubscriptionModel model)
        {
            var status = await this.GetStatus("DAC"); //Deactivated status 
            model.StatusID = status.ID;

            await this.UpdateUserSubscription(model);
        }

        /// <summary>
        /// Activate UserSubscription
        /// </summary>
        /// <param name="userSubscriptionID"></param>
        /// <returns></returns>
        public async Task ActivateUserSubscription(UserSubscriptionModel model)
        {
            var status = await this.GetStatus("ACT"); //Deactivated status 
            model.StatusID = status.ID;

            await this.UpdateUserSubscription(model);
        }
        #endregion

        #region Local Methods
        private async Task SendEmailOnSignup(UserModel userModel)
        {
            Tuple<string, string> sender = new Tuple<string, string>(SubscriptionMessages.EmailSenderAddress, SubscriptionMessages.EmailSenderName);
            Tuple<string, string> receiver = new Tuple<string, string>(userModel.Email, userModel.FullName);
            await EmailSender.Send(sender, SubscriptionMessages.SignUpEmailSubject, SubscriptionMessages.SignUpEmailBody, receiver);
        }
        #endregion

    }
}