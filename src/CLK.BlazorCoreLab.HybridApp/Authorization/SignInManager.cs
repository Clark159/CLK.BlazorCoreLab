using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CLK.BlazorCoreLab.HybridApp
{
    public class SignInManager
    {
        // Properties
        public ClaimsPrincipal User { get; private set; } = new();


        // Methods
        public Task SignInAsync(ClaimsPrincipal user)
        {
            #region Contracts

            if (user == null) throw new ArgumentException($"{nameof(user)}=null");

            #endregion

            // Require
            if(user == null) user = new();

            // Set
            this.User = user;

            // Raise
            this.OnUserChanged(user);

            // Return
            return Task.CompletedTask;
        }


        // Events
        public event Action<ClaimsPrincipal>? UserChanged;
        protected void OnUserChanged(ClaimsPrincipal user)
        {
            #region Contracts

            if (user == null) throw new ArgumentException($"{nameof(user)}=null");

            #endregion

            // Raise
            var handler = this.UserChanged;
            if (handler != null)
            {
                handler(user);
            }
        }
    }
}
