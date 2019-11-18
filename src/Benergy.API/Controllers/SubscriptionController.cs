using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Benergy.Core.Helpers;
using Benergy.Core.Models.API;
using Benergy.Modules.Subscription.Domain;
using Benergy.Modules.Subscription.Models;
using Benergy.Modules.Subscription.Common;
using Microsoft.AspNetCore.Mvc;

namespace Benergy.API.Controllers
{
    /// <summary>
    /// Subscription api controller
    /// </summary>
    [Route("api/[controller]")]
    public class SubscriptionController : Controller
    {
        private SubscriptionDomain _domain;

        public SubscriptionController(SubscriptionDomain domain)
        {
            this._domain = domain;
        }

        #region Plan

        /// <summary>
        /// Retrieves all subscription plans
        /// </summary>
        /// <response code="200">Plans fetched</response>
        /// <response code="400">Plan has missing/invalid values</response>
        /// <response code="500">Oops! Can't get list plans right now</response>
        [Route("Plan")]
        [HttpGet]
        [ProducesResponseType(typeof(APIResponseModel<PlanModel>), 200)]
        [ProducesResponseType(typeof(IDictionary<string, string>), 400)]
        [ProducesResponseType(typeof(void), 500)]
        public async Task<APIResponseModel<List<PlanModel>>> GetPlans()
        {
            return await APIHelper.GetAsync(m => _domain.GetPlans());
        }

        /// <summary>
        /// Retrieves a specific subscription plan by id
        /// </summary>
        /// <response code="200">Plan fetched</response>
        /// <response code="400">Plan has missing/invalid values</response>
        /// <response code="500">Oops! Can't get your plan right now</response>
        [Route("Plan/{id}")]
        [HttpGet]
        [ProducesResponseType(typeof(APIResponseModel<PlanModel>), 200)]
        [ProducesResponseType(typeof(IDictionary<string, string>), 400)]
        [ProducesResponseType(typeof(void), 500)]
        public async Task<APIResponseModel<PlanModel>> GetPlan(int id)
        {
            return await APIHelper.GetAsync(m => _domain.GetPlan(id));
        }
        #endregion

        #region Status

        /// <summary>
        /// Retrieves all subscription status
        /// </summary>
        /// <response code="200">Status fetched</response>
        /// <response code="400">Status has missing/invalid values</response>
        /// <response code="500">Oops! Can't get list Statuses right now</response>
        [Route("Status")]
        [HttpGet]
        [ProducesResponseType(typeof(APIResponseModel<StatusModel>), 200)]
        [ProducesResponseType(typeof(IDictionary<string, string>), 400)]
        [ProducesResponseType(typeof(void), 500)]
        public async Task<APIResponseModel<List<StatusModel>>> GetStatuses()
        {
            return await APIHelper.GetAsync(m => _domain.GetStatuses());
        }

        /// <summary>
        /// Retrieves a specific subscription status by id
        /// </summary>
        /// <response code="200">Status fetched</response>
        /// <response code="400">Status has missing/invalid values</response>
        /// <response code="500">Oops! Can't get your status right now</response>
        [Route("Status/{id}")]
        [HttpGet]
        [ProducesResponseType(typeof(APIResponseModel<StatusModel>), 200)]
        [ProducesResponseType(typeof(IDictionary<string, string>), 400)]
        [ProducesResponseType(typeof(void), 500)]
        public async Task<APIResponseModel<StatusModel>> GetStatus(int id)
        {
            return await APIHelper.GetAsync(m => _domain.GetStatus(id));
        }
        #endregion

        #region User
        /// <summary>
        /// Retrieves all users
        /// </summary>
        /// <response code="200">Users fetched</response>
        /// <response code="400">User has missing/invalid values</response>
        /// <response code="500">Oops! Can't get users right now</response>
        [Route("User")]
        [HttpGet]
        [ProducesResponseType(typeof(APIResponseModel<UserModel>), 200)]
        [ProducesResponseType(typeof(IDictionary<string, string>), 400)]
        [ProducesResponseType(typeof(void), 500)]
        public async Task<APIResponseModel<List<UserModel>>> GetUsers()
        {
            return await APIHelper.GetAsync(m => _domain.GetUsers());
        }

        /// <summary>
        /// Retrieves a specific user by id
        /// </summary>
        /// <response code="200">User fetched</response>
        /// <response code="400">User has missing/invalid values</response>
        /// <response code="500">Oops! Can't get user right now</response>
        [Route("User/{id}")]
        [HttpGet]
        [ProducesResponseType(typeof(APIResponseModel<UserModel>), 200)]
        [ProducesResponseType(typeof(IDictionary<string, string>), 400)]
        [ProducesResponseType(typeof(void), 500)]
        public async Task<APIResponseModel<UserModel>> GetUser(int id)
        {
            return await APIHelper.GetAsync(m => _domain.GetUser(id));
        }


        /// <summary>
        /// Create single user
        /// </summary>
        /// <response code="200">User created</response>
        /// <response code="400">User has missing/invalid values</response>
        /// <response code="500">Oops! Can't add your user right now</response>
        [Route("User")]
        [HttpPost]
        [ProducesResponseType(typeof(APIResponseModel<NTModel>), 200)]
        [ProducesResponseType(typeof(IDictionary<string, string>), 400)]
        [ProducesResponseType(typeof(void), 500)]
        public async Task<APIResponseModel<NTModel>> AddUser([FromBody] UserModel model)
        {
            return await APIHelper.SaveAsync(m => _domain.AddUser(model), SubscriptionMessages.UserAddedSuccess);
        }

        /// <summary>
        /// Update existing user
        /// </summary>
        /// <response code="200">User updated</response>
        /// <response code="400">User has missing/invalid values</response>
        /// <response code="500">Oops! Can't update your user right now</response>
        [Route("User")]
        [HttpPut]
        [ProducesResponseType(typeof(APIResponseModel<NTModel>), 200)]
        [ProducesResponseType(typeof(IDictionary<string, string>), 400)]
        [ProducesResponseType(typeof(void), 500)]
        public async Task<APIResponseModel<NTModel>> UpdateUser([FromBody] UserModel model)
        {
            return await APIHelper.SaveAsync(m => _domain.UpdateUser(model), SubscriptionMessages.UserUpdatedSuccess);
        }

         /// <summary>
        /// Change Password
        /// </summary>
        /// <response code="200">User password updated</response>
        /// <response code="400">User has missing/invalid values</response>
        /// <response code="500">Oops! Can't update your user's password right now</response>
        [Route("User/ChangePassword")]
        [HttpPut]
        [ProducesResponseType(typeof(APIResponseModel<NTModel>), 200)]
        [ProducesResponseType(typeof(IDictionary<string, string>), 400)]
        [ProducesResponseType(typeof(void), 500)]
        public async Task<APIResponseModel<NTModel>> UpdateUserPassword([FromBody] UserModel model)
        {
            return await APIHelper.SaveAsync(m => _domain.UpdateUserPassword(model), SubscriptionMessages.UserPasswordUpdateSuccess);
        }

        /// <summary>
        /// Delete existing user
        /// </summary>
        /// <response code="200">User deleted</response>
        /// <response code="400">User has missing/invalid values</response>
        /// <response code="500">Oops! Can't delete your user right now</response>
        [Route("User/{id}")]
        [HttpDelete]
        [ProducesResponseType(typeof(APIResponseModel<NTModel>), 200)]
        [ProducesResponseType(typeof(IDictionary<string, string>), 400)]
        [ProducesResponseType(typeof(void), 500)]
        public async Task<APIResponseModel<NTModel>> DeleteUser([FromBody] int id)
        {
            return await APIHelper.SaveAsync(m => _domain.DeleteUser(id), SubscriptionMessages.UserDeleteSuccess);
        }

        #endregion

        #region UserSubscription
        /// <summary>
        /// Retrieves all user subscriptions
        /// </summary>
        /// <response code="200">UserSubscriptions fetched</response>
        /// <response code="400">User has missing/invalid values</response>
        /// <response code="500">Oops! Can't get user subscriptions right now</response>
        [Route("UserSubscription")]
        [HttpGet]
        [ProducesResponseType(typeof(APIResponseModel<UserSubscriptionModel>), 200)]
        [ProducesResponseType(typeof(IDictionary<string, string>), 400)]
        [ProducesResponseType(typeof(void), 500)]
        public async Task<APIResponseModel<List<UserSubscriptionModel>>> GetUserSubscriptions()
        {
            return await APIHelper.GetAsync(m => _domain.GetUserSubscriptions());
        }

        /// <summary>
        /// Retrieves user subscriptions by user
        /// </summary>
        /// <response code="200">UserSubscriptions fetched</response>
        /// <response code="400">User has missing/invalid values</response>
        /// <response code="500">Oops! Can't get user subscriptions right now</response>
        [Route("Users/{userID}/UserSubscription")]
        [HttpGet]
        [ProducesResponseType(typeof(APIResponseModel<UserSubscriptionModel>), 200)]
        [ProducesResponseType(typeof(IDictionary<string, string>), 400)]
        [ProducesResponseType(typeof(void), 500)]
        public async Task<APIResponseModel<List<UserSubscriptionModel>>> GetUserSubscriptions(int userID)
        {
            return await APIHelper.GetAsync(m => _domain.GetUserSubscription(userID));
        }

        /// <summary>
        /// Retrieves a specific user subscription by id
        /// </summary>
        /// <response code="200">UserSubscription fetched</response>
        /// <response code="400">UserSubscription has missing/invalid values</response>
        /// <response code="500">Oops! Can't get User Subscription right now</response>
        [Route("UserSubscription/{id}")]
        [HttpGet]
        [ProducesResponseType(typeof(APIResponseModel<UserSubscriptionModel>), 200)]
        [ProducesResponseType(typeof(IDictionary<string, string>), 400)]
        [ProducesResponseType(typeof(void), 500)]
        public async Task<APIResponseModel<UserSubscriptionModel>> GetUserSubscription(int id)
        {
            return await APIHelper.GetAsync(m => _domain.GetUserSubscriptionByID(id));
        }


        /// <summary>
        /// Create single user subscription
        /// </summary>
        /// <response code="200">User subscription created</response>
        /// <response code="400">User has missing/invalid values</response>
        /// <response code="500">Oops! Can't add your user subscription right now</response>
        [Route("UserSubscription")]
        [HttpPost]
        [ProducesResponseType(typeof(APIResponseModel<NTModel>), 200)]
        [ProducesResponseType(typeof(IDictionary<string, string>), 400)]
        [ProducesResponseType(typeof(void), 500)]
        public async Task<APIResponseModel<NTModel>> AddUserSubscription([FromBody] UserSubscriptionModel model)
        {
            return await APIHelper.SaveAsync(m => _domain.AddUserSubscription(model), SubscriptionMessages.UserSubscriptionAddedSuccess);
        }

        /// <summary>
        /// Update existing user subscription
        /// </summary>
        /// <response code="200">User subscription updated</response>
        /// <response code="400">User subscription has missing/invalid values</response>
        /// <response code="500">Oops! Can't update your user subscription right now</response>
        [Route("UserSubscription")]
        [HttpPut]
        [ProducesResponseType(typeof(APIResponseModel<NTModel>), 200)]
        [ProducesResponseType(typeof(IDictionary<string, string>), 400)]
        [ProducesResponseType(typeof(void), 500)]
        public async Task<APIResponseModel<NTModel>> UpdateUserSubscription([FromBody] UserSubscriptionModel model)
        {
            return await APIHelper.SaveAsync(m => _domain.UpdateUserSubscription(model), SubscriptionMessages.UserSubscriptionUpdatedSuccess);
        }

        /// <summary>
        /// Delete existing user subscription
        /// </summary>
        /// <response code="200">User subscription deleted</response>
        /// <response code="400">User subscription has missing/invalid values</response>
        /// <response code="500">Oops! Can't delete your user subscription right now</response>
        [Route("UserSubscription/{id}")]
        [HttpDelete]
        [ProducesResponseType(typeof(APIResponseModel<NTModel>), 200)]
        [ProducesResponseType(typeof(IDictionary<string, string>), 400)]
        [ProducesResponseType(typeof(void), 500)]
        public async Task<APIResponseModel<NTModel>> DeleteUserSubscription([FromBody] int id)
        {
            return await APIHelper.SaveAsync(m => _domain.DeleteUserSubscription(id), SubscriptionMessages.UserSubscriptionDeleteSuccess);
        }

        /// <summary>
        /// Deactivate existing user subscription
        /// </summary>
        /// <response code="200">User subscription deactivated</response>
        /// <response code="400">User subscription has missing/invalid values</response>
        /// <response code="500">Oops! Can't deactivate your user subscription right now</response>
        [Route("UserSubscription/Deactivate")]
        [HttpPut]
        [ProducesResponseType(typeof(APIResponseModel<NTModel>), 200)]
        [ProducesResponseType(typeof(IDictionary<string, string>), 400)]
        [ProducesResponseType(typeof(void), 500)]
        public async Task<APIResponseModel<NTModel>> DeactivateUserSubscription([FromBody] UserSubscriptionModel model)
        {
            return await APIHelper.SaveAsync(m => _domain.DeactivateUserSubscription(model), SubscriptionMessages.UserSubscriptionDeactivatedSuccess);
        }

        /// <summary>
        /// Activate existing user subscription
        /// </summary>
        /// <response code="200">User subscription activated</response>
        /// <response code="400">User subscription has missing/invalid values</response>
        /// <response code="500">Oops! Can't activate your user subscription right now</response>
        [Route("UserSubscription/Activate")]
        [HttpPut]
        [ProducesResponseType(typeof(APIResponseModel<NTModel>), 200)]
        [ProducesResponseType(typeof(IDictionary<string, string>), 400)]
        [ProducesResponseType(typeof(void), 500)]
        public async Task<APIResponseModel<NTModel>> ActivateUserSubscription([FromBody] UserSubscriptionModel model)
        {
            return await APIHelper.SaveAsync(m => _domain.ActivateUserSubscription(model), SubscriptionMessages.UserSubscriptionActivatedSuccess);
        }

        #endregion
        
    }
}
