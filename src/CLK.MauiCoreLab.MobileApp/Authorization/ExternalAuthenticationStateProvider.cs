using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Authorization;

namespace CLK.MauiCoreLab.MobileApp
{
    public class ExternalAuthenticationStateProvider : AuthenticationStateProvider
    {
        // Fields
        private SignInManager _authenticationService;


        // Constructors
        public ExternalAuthenticationStateProvider(SignInManager authenticationService)
        {
            #region Contracts

            if (authenticationService == null) throw new ArgumentException($"{nameof(authenticationService)}=null");

            #endregion

            // Default
            _authenticationService = authenticationService;

            // Event
            authenticationService.UserChanged += this.AuthenticationService_UserChanged;
        }


        // Methods
        public override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            // Return
            return Task.FromResult(new AuthenticationState(_authenticationService.User));
        }


        // Handlers
        private void AuthenticationService_UserChanged(ClaimsPrincipal claimsPrincipal)
        {
            #region Contracts

            if (claimsPrincipal == null) throw new ArgumentException($"{nameof(claimsPrincipal)}=null");

            #endregion

            // Notify
            this.NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(_authenticationService.User)));
        }
    }
}