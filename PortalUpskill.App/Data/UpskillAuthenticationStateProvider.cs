using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Newtonsoft.Json;
using PortalUpskill.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PortalUpskill.App.Data
{
    public class UpskillAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly ProtectedSessionStorage _sessionStorage;

        public UpskillAuthenticationStateProvider(ProtectedSessionStorage sessionStorage)
        {
            _sessionStorage = sessionStorage;
        }
        /// <summary>
        /// Corre quando a aplicação é iniciada ou quando a página é refreshed
        /// Significa que é preciso manter autenticação na sessão para evitar logout on refresh
        /// </summary>
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            //confirmar se o user já logou esta sessão (váriavel de sessão userEmail)
            Pessoa user = null;
            var readUserFromSession = await _sessionStorage.GetAsync<string>("user");
            if( readUserFromSession.Success)
            {
                user = JsonConvert.DeserializeObject<Pessoa>(readUserFromSession.Value);
            }

            ClaimsIdentity identity;
            if (user != null)
            {
                identity = GetIdentityClaims(user);
            }
            else
            {
                identity = new ClaimsIdentity();
            }

            var userClaimsPrincipal = new ClaimsPrincipal(identity);
            return await Task.FromResult(new AuthenticationState(userClaimsPrincipal));
        }

        /// <summary>
        /// Marca o utilizador como autorizado e atribui correctamente os 
        /// Claim.Roles consoante o perfil na BD
        /// </summary>
        /// <param name="user">Objecto do tipo Pessoa de onde vão ser inferidos os roles</param>
        public void MarkUserAsAuthenticated(Pessoa pessoa)
        {
            ClaimsIdentity identity = GetIdentityClaims(pessoa);

            ClaimsPrincipal user = new ClaimsPrincipal(identity);
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
        }
        public void MarkUserAsLoggedOut()
        {
            _sessionStorage.DeleteAsync("user");
            var identity = new ClaimsIdentity();
            var user = new ClaimsPrincipal(identity);
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
        }
        private ClaimsIdentity GetIdentityClaims(Pessoa user)
        {
            return new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, user.Email),
                new Claim(ClaimTypes.Role, user.Perfil.Nome)
            }, "apiauth_type");
        }
    }
}
